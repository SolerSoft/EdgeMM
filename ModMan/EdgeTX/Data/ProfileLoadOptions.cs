namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Defines which templates to load.
    /// </summary>
    [Flags]
    public enum ModelTemplateSources
    {
        /// <summary>
        /// No templates will be loaded.
        /// </summary>
        None = 0,

        /// <summary>
        /// Personal templates will be loaded.
        /// </summary>
        Personal = 1,

        /// <summary>
        /// System templates (such as wizards) will be loaded.
        /// </summary>
        System = 2,

        /// <summary>
        /// All templates will be loaded.
        /// </summary>
        All = 5
    }

    /// <summary>
    /// Controls how profiles are loaded.
    /// </summary>
    public class ProfileLoadOptions
    {
        #region Static Public Properties

        /// <summary>
        /// Gets the default <see cref="ProfileLoadOptions" />.
        /// </summary>
        public static ProfileLoadOptions Default { get; private set; } = new ProfileLoadOptions()
        {
            IncludeModels = true,
            IncludeTemplates = ModelTemplateSources.Personal,
        };

        #endregion Static Public Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether to load the models.
        /// </summary>
        /// <value>
        /// <c>true</c> if the models should be loaded; otherwise, <c>false</c>.
        /// </value>
        public bool IncludeModels { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to load the model templates.
        /// </summary>
        /// <value>
        /// <c>true</c> if the model templates should be loaded; otherwise, <c>false</c>.
        /// </value>
        public ModelTemplateSources IncludeTemplates { get; set; }

        #endregion Public Properties
    }
}