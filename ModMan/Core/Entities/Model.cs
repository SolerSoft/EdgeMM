namespace ModMan.Core.Entities
{
    using LogicalSwitchCollection = EntityCollection<LogicalSwitch>;

    /// <summary>
    /// Represents an EdgeTX RC model.
    /// </summary>
    public class Model : NamedEntity
    {
        #region Constants


        #endregion Constants

        #region Private Fields

        private string category;
        private bool isTemplate;
        private LogicalSwitchCollection logicalSwitches = new();

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
            get => category;
            set => SetProperty(ref category, value);
        }

        /// <summary>
        /// Gets or sets a value that indicates if the model is a template.
        /// </summary>
        /// <value>
        /// <c>true</c> if the model is a template; otherwise <c>false</c>.
        /// </value>
        public bool IsTemplate
        {
            get => isTemplate;
            set => SetProperty(ref isTemplate, value);
        }

        /// <summary>
        /// Gets the collection of logical switches for the model.
        /// </summary>
        /// <value>
        /// The collection of logical switches for the model.
        /// </value>
        public LogicalSwitchCollection LogicalSwitches
        {
            get => logicalSwitches;
            set => SetProperty(ref logicalSwitches, value);
        }

        #endregion Public Properties
    }
}