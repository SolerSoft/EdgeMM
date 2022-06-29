using EdgeMM.Entities;

namespace EdgeMM.Managers
{
    /// <summary>
    /// A class for loading, saving and managing profiles.
    /// </summary>
    public class ProfileManager
    {
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
        private Task LoadModelsAsync(Profile profile)
        {
        }

        /// <summary>
        /// Loads the model templates for the specified profile.
        /// </summary>
        /// <param name="profile">
        /// The profile to load the templates for.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that represents the operation.
        /// </returns>
        private Task LoadTemplatesAsync(Profile profile)
        {
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Loads a <see cref="Profile" /> from the given path.
        /// </summary>
        /// <param name="path">
        /// The system path to the profile.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the <see cref="Profile" />.
        /// </returns>
        public async Task<Profile> LoadProfileAsync(string path)
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

            // Load the templates
            await LoadTemplatesAsync(profile);

            // Load the models
            await LoadModelsAsync(profile);

            // Done loading
            return profile;
        }

        #endregion Public Methods
    }
}