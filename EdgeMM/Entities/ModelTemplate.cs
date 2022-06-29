namespace EdgeMM.Entities
{
    /// <summary>
    /// Represents an EdgeTX RC model template.
    /// </summary>
    public class ModelTemplate : Model
    {
        #region Private Fields

        private string folder;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the folder where the template resides.
        /// </summary>
        /// <value>
        /// The name of the folder where the template resides.
        /// </value>
        public string Folder
        {
            get { return folder; }
            set { SetProperty(ref folder, value); }
        }

        #endregion Public Properties
    }
}