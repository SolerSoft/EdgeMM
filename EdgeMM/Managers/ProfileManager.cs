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

        private const string MODELS_DIR = "MODELS";
        private const string MODELS_FILE = "models.yml";
        private const string TEMPLATES_DIR = "TEMPLATES";
        private const string TEMPLATES_PERSONAL_DIR = "PERSONAL";

        #endregion Constants

        #region Private Methods

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
            string modelsFileDir = Path.Combine(Path.GetDirectoryName(profile.Path), MODELS_DIR);
            string modelsFilePath = Path.Combine(modelsFileDir, MODELS_FILE);

            // If there is no models file, warn and exit
            if (!File.Exists(modelsFilePath))
            {
                Log.Warning($"Models file '{MODELS_FILE}' could not be found at '{modelsFileDir}'.");
                return;
            }

            // Load the models yaml
            var serializer = new Serializer();
            var modelsData = serializer.Deserialize<ModelsData>(File.ReadAllText(modelsFilePath));

            // Level 1 is a list of dictionaries
            foreach (var categoryModels in modelsData)
            {
                // Level 2 is category -> models
                foreach (var category in categoryModels)
                {
                    // Level 3 are the models in this category
                    foreach (var model in category.Value)
                    {
                        profile.Models.Add(new Model()
                        {
                            Category = category.Key,
                            Name = model.Name,
                            Path = Path.Combine(modelsFileDir, model.FileName)
                        });
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
            Profile profile = new Profile()
            {
                Path = path,
            };

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