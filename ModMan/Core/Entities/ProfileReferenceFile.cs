using ModMan.Core.Providers;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// A reference to a file-based profile.
    /// </summary>
    public class ProfileReferenceFile : IProfileReference
    {
        #region Private Constructors

        /// <summary>
        /// Initialize a new <see cref="ProfileReferenceFile" />.
        /// </summary>
        /// <param name="provider">
        /// The provider that can load the profile.
        /// </param>
        /// <param name="path">
        /// The path to the file.
        /// </param>
        public ProfileReferenceFile(IProfileProvider provider, string path)
        {
            // Validate
            if (provider == null) { throw new ArgumentNullException(nameof(provider)); }
            if (string.IsNullOrEmpty(path)) { throw new ArgumentException(nameof(path)); }

            // Store
            Path = path;
            Provider = provider;
        }

        #endregion Private Constructors

        #region Public Properties

        /// <inheritdoc />
        public string Name { get; set; }

        public string Path { get; private set; }

        /// <inheritdoc />
        public IProfileProvider Provider { get; private set; }

        #endregion Public Properties
    }
}