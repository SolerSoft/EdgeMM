using ModMan.Core.Providers;

namespace ModMan.Core.Entities
{
    /// <summary>
    /// The interface for a reference to a profile.
    /// </summary>
    public interface IProfileReference
    {
        #region Public Properties

        /// <summary>
        /// Gets the name of the profile.
        /// </summary>
        /// <value>
        /// The name of the profile.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the <see cref="IProfileProvider" /> that can provide the profile.
        /// </summary>
        IProfileProvider Provider { get; }

        #endregion Public Properties
    }
}