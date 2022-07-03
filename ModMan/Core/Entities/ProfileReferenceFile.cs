using ModMan.Core.Providers;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// A reference to a profile.
    /// </summary>
    public class ProfileReference : Entity
    {
        #region Private Fields

        private string name;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        /// Initialize a new <see cref="ProfileReference" />.
        /// </summary>
        /// <param name="provider">
        /// The provider that can load the profile.
        /// </param>
        public ProfileReference(IProfileProvider provider)
        {
            // Validate
            if (provider == null) { throw new ArgumentNullException(nameof(provider)); }

            // Store
            Provider = provider;
        }

        #endregion Private Constructors

        #region Public Properties

        /// <inheritdoc />
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        /// <inheritdoc />
        public IProfileProvider Provider { get; private set; }

        #endregion Public Properties
    }
}