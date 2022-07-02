using ModMan.Providers;
using System.Collections.ObjectModel;
using IOPath = System.IO.Path;
using ModelCollection = ModMan.Entities.EntityCollection<ModMan.Entities.IModel, ModMan.Entities.EdgeTX.Model>;

namespace ModMan.Entities
{
    /// <summary>
    /// A reference to a file-based profile.
    /// </summary>
    public class ProfileReferenceFile : FileObject, IProfileReference
    {
        #region Public Properties

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public IProfileProvider Provider { get; set; }

        #endregion Public Properties
    }
}