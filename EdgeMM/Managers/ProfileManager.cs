using EdgeMM.Data;
using EdgeMM.Entities;
using Serilog;
using SharpYaml.Serialization;

namespace EdgeMM.Managers
{
    /// <summary>
    /// A class for loading, saving and managing profiles.
    /// </summary>
    public class ProfileManager
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
        /// Initializes a new <see cref="ProfileManager" /> instance.
        /// </summary>
        public ProfileManager()
        {
            var settings = new SerializerSettings() { LimitPrimitiveFlowSequence = 0, SerializeDictionaryItemsAsMembers = true };
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

            return new Model()
            {
                Category = modelRef.Category,
                IsTemplate = modelRef.IsTemplate,
                Name = modelRef.Name,
                Path = modelFilePath
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
                        modelRef.IsTemplate = false;

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

        /// <summary>
        /// Loads a <see cref="Profile" /> from the given path.
        /// </summary>
        /// <param name="path">
        /// The system path to the profile.
        /// </param>
        /// <param name="options">
        /// The <see cref="ProfileLoadOptions" /> that control how data is loaded.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the <see cref="Profile" />.
        /// </returns>
        public async Task<Profile> LoadProfileAsync(string path, ProfileLoadOptions options)
        {
            // Validate
            if (string.IsNullOrEmpty(path)) { throw new ArgumentException(nameof(path)); }

            // Make sure file exists
            if (!File.Exists(path)) { throw new FileNotFoundException($"The profile '{path}' was not found."); }

            // TODO: Load the name

            // Create the profile
            Profile profile = new Profile() { Path = path };

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

        /// <summary>
        /// Loads a <see cref="Profile" /> from the given path.
        /// </summary>
        /// <param name="path">
        /// The system path to the profile.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the <see cref="Profile" />.
        /// </returns>
        public Task<Profile> LoadProfileAsync(string path)
        {
            return LoadProfileAsync(path, ProfileLoadOptions.Default);
        }

        #endregion Public Methods
    }
}