using ModMan.Validation;
using Plugin.ValidationRules.Extensions;

namespace ModMan.Core.Entities
{
    using LogicalSwitchCollection = EntityCollection<LogicalSwitch>;

    /// <summary>
    /// Represents a RC model.
    /// </summary>
    public class Model : NamedEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the maximum length allowed for the <see cref="NamedEntity.Name">Name</see> property.
        /// </summary>
        public static int NameMaxLength { get; set; } = -1;

        #endregion Public Properties

        #region Private Fields

        private string category;
        private bool isTemplate;
        private LogicalSwitchCollection logicalSwitches = new();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="Model" /> instance.
        /// </summary>
        public Model()
        {
            if (NameMaxLength > -1)
            {
                Name = Name.WithRule(new StringLengthRule(-1, NameMaxLength), "Name is too long");
            }
        }

        #endregion Public Constructors

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