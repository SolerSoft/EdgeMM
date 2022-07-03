using ModMan.Core.Entities;
using ModMan.EdgeTX.Data;

namespace ModMan.Core.Providers
{
    /// <summary>
    /// The interface for a provider that can read and write profile data.
    /// </summary>
    public interface IProfileProvider
    {
        #region Public Methods

        /// <summary>
        /// Gets a list of profiles that the provider can load.
        /// </summary>
        /// <returns>
        /// A <see cref="Task" /> that yields the result of the operation.
        /// </returns>
        Task<IEnumerable<IProfileReference>> GetProfilesAsync();

        /// <summary>
        /// Loads the referenced profile.
        /// </summary>
        /// <param name="reference">
        /// The reference to the profile to load.
        /// </param>
        /// <param name="options">
        /// The <see cref="ProfileLoadOptions" /> that control how data is loaded.
        /// </param>
        /// <returns>
        /// A <see cref="Task" /> that yields the result of the operation.
        /// </returns>
        Task<IProfile> LoadProfileAsync(IProfileReference reference, ProfileLoadOptions options);

        #endregion Public Methods
    }
}