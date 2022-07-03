namespace ModMan.Core.Entities
{
    /// <summary>
    /// The interface for a RC model.
    /// </summary>
    public interface IModel : IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the category of the model.
        /// </summary>
        /// <value>
        /// The category of the model.
        /// </value>
        string Category { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the model is a template.
        /// </summary>
        /// <value>
        /// <c>true</c> if the model is a template; otherwise <c>false</c>.
        /// </value>
        bool IsTemplate { get; }

        /// <summary>
        /// Gets or sets the name of the model.
        /// </summary>
        /// <value>
        /// The name of the model.
        /// </value>
        string Name { get; set; }

        #endregion Public Properties
    }
}