namespace EdgeMM.Data
{
    /// <summary>
    /// Base class for an object that has a name and is backed by a file.
    /// </summary>
    public abstract class NamedFileObject : NamedObject
    {
        #region Private Fields

        private string path;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the system path to where the object file can be found.
        /// </summary>
        /// <value>
        /// The path to the object file.
        /// </value>
        public string Path
        {
            get { return path; }
            set { SetProperty(ref path, value); }
        }

        #endregion Public Properties
    }
}