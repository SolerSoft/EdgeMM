using ModMan.Core.Entities;
using ModMan.Core.Providers;
using ModMan.Core.Serialization.Yaml;
using ModMan.EdgeTX.Data;
using ModMan.EdgeTX.Entities;
using ModMan.EdgeTX.Serialization;
using Serilog;
using SharpYaml.Serialization;

namespace ModMan.EdgeTX.Providers
{
    /// <summary>
    /// A provider that can read and write EdgeTX profile data.
    /// </summary>
    public class ProfileProvider : IProfileProvider
    {
        #region Constants

        private const string MODELS_FILE = "models.yml";
        private const string TEMPLATES_PERSONAL_DIR = "PERSONAL";

        #endregion Constants

        #region Private Fields

        private Serializer serializer;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="ProfileProvider" /> instance.
        /// </summary>
        public ProfileProvider()
        {
            // Create the settings
            var settings = new SerializerSettings() { LimitPrimitiveFlowSequence = 0, SerializeDictionaryItemsAsMembers = true };

            // Add custom converters
            settings.RegisterSerializerFactory(new LogicalSwitchFunctionConverter());
            settings.RegisterSerializerFactory(new VersionConverter());

            // Create the serializer
            serializer = new Serializer(settings);
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Loads the model at the specified path.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the model from.
        /// </param>
        /// <param name="modelRef">
        /// A <see cref="ModelReferenceData" /> specifying which model to load.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the <see cref="Model" />.
        /// </returns>
        private async Task<Model> LoadModelAsync(Profile profile, ModelReferenceData modelRef)
        {
            // Calculate the path to the models file
            string modelFilePath = Path.Combine(profile.ModelsPath, modelRef.FileName);

            // If there is no models file, warn and exit
            if (!File.Exists(modelFilePath))
            {
                throw new FileNotFoundException("Model file could not be found.", modelFilePath);
            }

            // Load the model yaml
            var modelData = serializer.Deserialize<ModelData>(await File.ReadAllTextAsync(modelFilePath));

            // Wrap in entity
            return new Model(modelFilePath, modelData)
            {
                Category = modelRef.Category,
            };
        }

        /// <summary>
        /// Loads the models for the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the models for.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that represents the operation.
        /// </returns>
        private async Task LoadModelsAsync(Profile profile)
        {
            // Calculate the path to the models file
            string modelsFilePath = Path.Combine(profile.ModelsPath, MODELS_FILE);

            // If there is no models file, warn and exit
            if (!File.Exists(modelsFilePath))
            {
                Log.Warning($"Models file could not be found at '{modelsFilePath}'.");
                return;
            }

            // Load the models yaml
            var modelsData = serializer.Deserialize<ModelsData>(await File.ReadAllTextAsync(modelsFilePath));

            // Level 1 is a list of dictionaries
            foreach (var categoryModels in modelsData)
            {
                // Level 2 is category -> models
                foreach (var category in categoryModels)
                {
                    // Level 3 are the models in this category
                    foreach (var modelRef in category.Value)
                    {
                        // Add the category and template into the reference data
                        modelRef.Category = category.Key;

                        // Load and add the model
                        profile.Models.Add(await LoadModelAsync(profile, modelRef));
                    }
                }
            }
        }

        /// <summary>
        /// Loads the model templates for the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the templates for.
        /// </param>
        /// <param name="sources">
        /// The sources to load the templates from.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that represents the operation.
        /// </returns>
        private Task LoadTemplatesAsync(Profile profile, ModelTemplateSources sources)
        {
            return Task.CompletedTask;
        }

        #endregion Private Methods

        #region Public Methods

        /// <inheritdoc />
        public Task<IEnumerable<IProfileReference>> GetProfilesAsync()
        {
            // Create an output list
            List<IProfileReference> profiles = new();

            // Get all the version files (there will only be one)
            var files = Directory.GetFiles(@"C:\tmp\SD", "edgetx.sdcard.version");

            // Add a profile for each version file
            foreach (var file in files)
            {
                profiles.Add(new ProfileReferenceFile(this, file)
                {
                    Name = Path.GetFileName(file),
                });
            }

            // Return the profiles
            return Task.FromResult<IEnumerable<IProfileReference>>(profiles);
        }

        /// <inheritdoc />
        public async Task<IProfile> LoadProfileAsync(IProfileReference reference, ProfileLoadOptions options)
        {
            // Validate
            if (reference == null) { throw new ArgumentNullException(nameof(reference)); }

            // Cast
            var proRef = (ProfileReferenceFile)reference;

            // Make sure file exists
            if (!File.Exists(proRef.Path)) { throw new FileNotFoundException($"The profile '{proRef.Path}' was not found."); }

            // TODO: Load the name

            // Create the profile
            Profile profile = new Profile(proRef.Path);

            // Load the templates?
            if (options.IncludeTemplates != ModelTemplateSources.None)
            {
                await LoadTemplatesAsync(profile, options.IncludeTemplates);
            }

            // Load the models?
            if (options.IncludeModels)
            {
                await LoadModelsAsync(profile);
            }

            // Done loading
            return profile;
        }

        #endregion Public Methods
    }
}