using ModMan.Core.Entities;

namespace ModMan.Core.Entities
{
    using ModelCollection = EntityCollection<Model>;

    /// <summary>
    /// Represents an EdgeTX profile, often stored on a SD Card.
    /// </summary>
    public class Profile : NamedEntity
    {
        #region Private Fields

        private ModelCollection models = new();
        private ModelCollection templates = new();

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the list of models stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of models stored within the <see cref="Profile" />.
        /// </value>
        public ModelCollection Models
        {
            get => models;
            set => SetProperty(ref models, value);
        }

        /// <summary>
        /// Gets or sets the list of model templates stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of model templates stored within the <see cref="Profile" />.
        /// </value>
        public ModelCollection Templates
        {
            get => templates;
            set => SetProperty(ref templates, value);
        }

        #endregion Public Properties
    }
}