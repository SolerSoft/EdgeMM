using ModMan.Core.Entities;
using ModMan.Core.Providers;
using ModMan.Core.Serialization.Yaml;
using ModMan.EdgeTX.Data;
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
        private const string TEMPLATES_DIR = "TEMPLATES";
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
            settings.RegisterSerializerFactory(new TimeSpanConverter());

            // Create the serializer
            serializer = new Serializer(settings);
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Loads switches fr
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelData"></param>
        static private void LoadLogicalSwitches(Model model, ModelData modelData)
        {
            // If we have no switches to load, nothing to do
            if (modelData.LogicalSwitches == null) { return; }

            // Load all switches
            foreach (LogicalSwitchData switchData in modelData.LogicalSwitches.Values)
            {
                model.LogicalSwitches.Add(new LogicalSwitch()
                {
                    Source = switchData,
                    AndSwitch = switchData.AndSwitch,
                    Comment = switchData.Comment,
                    Definition = switchData.Definition,
                    Delay = switchData.Delay,
                    Duration = switchData.Duration,
                    Function = switchData.Function,
                    Name = switchData.Name,
                });
            }
        }

        /// <summary>
        /// Loads the model at the specified path.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the model from.
        /// </param>
        /// <param name="profileData">
        /// The profile data from storage.
        /// </param>
        /// <param name="modelRefData">
        /// The model reference data from storage.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the <see cref="Model" />.
        /// </returns>
        private async Task<Model> LoadModelAsync(Profile profile, ProfileData profileData, ModelReferenceData modelRefData)
        {
            // Calculate the path to the models file
            string path = Path.Combine(profileData.ModelsPath, modelRefData.FileName);

            // If there is no models file, warn and exit
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Model file could not be found.", path);
            }

            // Load the model from yaml
            var modelData = serializer.Deserialize<ModelData>(await File.ReadAllTextAsync(path));
            modelData.Path = path;

            // Convert to model
            var model = new Model()
            {
                Category = modelRefData.Category,
                IsTemplate = path.Contains(TEMPLATES_DIR),
                Name = modelData.Header.Name,
                Source = modelData,
            };

            // Load the switches
            LoadLogicalSwitches(model, modelData);

            // Done!
            return model;
        }

        /// <summary>
        /// Loads the models for the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the models for.
        /// </param>
        /// <param name="profileData">
        /// The profile data from storage.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that represents the operation.
        /// </returns>
        private async Task LoadModelsAsync(Profile profile, ProfileData profileData)
        {
            // Calculate the path to the models file
            string modelsFilePath = Path.Combine(profileData.ModelsPath, MODELS_FILE);

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
                        profile.Models.Add(await LoadModelAsync(profile, profileData, modelRef));
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
        public Task<IEnumerable<ProfileReference>> GetProfilesAsync()
        {
            // Create an output list
            List<ProfileReference> profiles = new();

            // Get all the version files (there will only be one)
            var files = Directory.GetFiles(@"C:\tmp\SD", "edgetx.sdcard.version");

            // Add a profile for each version file
            foreach (var file in files)
            {
                profiles.Add(new ProfileReference(this)
                {
                    Name = Path.GetFileName(file),
                    Source = new ProfileReferenceData() { Path = file },
                });
            }
            
            // Return the profiles
            return Task.FromResult<IEnumerable<ProfileReference>>(profiles);
        }

        /// <inheritdoc />
        public async Task<Profile> LoadProfileAsync(ProfileReference reference, ProfileLoadOptions options)
        {
            // Validate
            if (reference == null) { throw new ArgumentNullException(nameof(reference)); }

            // Get our data
            var profileRefData = (ProfileReferenceData)reference.Source;

            // Make sure file exists
            if (!File.Exists(profileRefData.Path)) { throw new FileNotFoundException($"The profile '{profileRefData.Path}' was not found."); }

            // Create the profile data
            var profileData = new ProfileData(profileRefData.Path);

            // Create the profile
            Profile profile = new Profile()
            {
                Source = profileData,
                Name = Path.GetFileName(profileRefData.Path), // TODO: Load the name
            };

            // Load the templates?
            if (options.IncludeTemplates != ModelTemplateSources.None)
            {
                await LoadTemplatesAsync(profile, options.IncludeTemplates);
            }

            // Load the models?
            if (options.IncludeModels)
            {
                await LoadModelsAsync(profile, profileData);
            }

            // Done loading
            return profile;
        }

        #endregion Public Methods
    }
}