namespace EdgeMM.Entities
{
    /// <summary>
    /// Represents an EdgeTX RC model.
    /// </summary>
    public class Model : NamedFileObject
    {
        #region Private Fields

        private string category;
        private string folder;
        private bool isTemplate;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the category of the model.
        /// </summary>
        /// <value>
        /// The category of the model.
        /// </value>
        public string Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        /// <summary>
        /// Gets or sets the name of the folder where the model resides.
        /// </summary>
        /// <value>
        /// The name of the folder where the model resides.
        /// </value>
        public string Folder
        {
            get { return folder; }
            set { SetProperty(ref folder, value); }
        }

        /// <summary>
        /// Gets or sets a value that indicates if the model is a template.
        /// </summary>
        /// <value>
        /// <c>true</c> if the model is a template; otherwise <c>false</c>.
        /// </value>
        public bool IsTemplate
        {
            get { return isTemplate; }
            set { SetProperty(ref isTemplate, value); }
        }

        #endregion Public Properties
    }
}