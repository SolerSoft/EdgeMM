namespace ModMan.Core.Entities
{
    /// <summary>
    /// The interface for a profile which contains models, templates, etc.
    /// </summary>
    public interface IProfile : IEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets the list of models stored within the profile.
        /// </summary>
        /// <value>
        /// The list of models stored within the profile.
        /// </value>
        IEntityCollection<IModel> Models { get; }

        /// <summary>
        /// Gets or sets the name of the profile.
        /// </summary>
        /// <value>
        /// The name of the profile.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets the list of model templates stored within the profile.
        /// </summary>
        /// <value>
        /// The list of model templates stored within the profile.
        /// </value>
        IEntityCollection<IModel> Templates { get; }

        #endregion Public Properties
    }
}