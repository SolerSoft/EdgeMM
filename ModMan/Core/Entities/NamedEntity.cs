namespace ModMan.Core.Entities
{
    /// <summary>
    /// Base class for an entity that has a name.
    /// </summary>
    public class NamedEntity : Entity
    {
        #region Private Fields

        private string name;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        #endregion Public Properties
    }
}