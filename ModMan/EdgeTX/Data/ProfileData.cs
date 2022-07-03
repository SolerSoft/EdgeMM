using IOPath = System.IO.Path;

namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Represents an EdgeTX profile.
    /// </summary>
    public class ProfileData
    {
        #region Constants

        private const string MODELS_DIR = "MODELS";
        private const string TEMPLATES_DIR = "TEMPLATES";

        #endregion Constants

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="ProfileData" /> instance.
        /// </summary>
        /// <param name="path">
        /// The path to the profile data master file.
        /// </param>
        /// <exception cref="ArgumentException">
        /// <paramref name="path" /> was invalid.
        /// </exception>
        public ProfileData(string path)
        {
            // Validate
            if (string.IsNullOrEmpty(path)) { throw new ArgumentException(nameof(path)); }

            // Store
            Path = path;

            // Calculate
            string directory = IOPath.GetDirectoryName(path);
            ModelsPath = IOPath.Combine(directory, MODELS_DIR);
            TemplatesPath = IOPath.Combine(directory, TEMPLATES_DIR);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the path to the model files stored within the profile.
        /// </summary>
        /// <value>
        /// The path to the model files stored within the profile.
        /// </value>
        public string ModelsPath { get; private set; }

        /// <summary>
        /// Gets the path to the profile main file.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Gets the path to the template files stored within the profile.
        /// </summary>
        /// <value>
        /// The path to the template files stored within the profile.
        /// </value>
        public string TemplatesPath { get; private set; }

        #endregion Public Properties
    }
}