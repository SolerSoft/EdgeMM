using ModMan.Data.EdgeTX;

namespace ModMan.Entities.EdgeTX
{
    /// <summary>
    /// Represents an EdgeTX RC model.
    /// </summary>
    public class Model : FileObject<ModelData>, IModel
    {
        #region Constants

        private const string TEMPLATES_DIR = "TEMPLATES";

        #endregion Constants

        #region Private Fields

        private string category;
        private string folder;
        private bool isTemplate;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="Model" /> with the specified backing data.
        /// </summary>
        /// <param name="modelData">
        /// The backing data for the model.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="modelData" /> is null.
        /// </exception>
        public Model(ModelData modelData) : base(modelData) { }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        /// Updates properties that are based on <see cref="Path" />.
        /// </summary>
        private void UpdatePathProperties()
        {
            // Kind of hacky...
            IsTemplate = Path != null && Path.Contains(TEMPLATES_DIR);
        }

        #endregion Private Methods

        #region Protected Methods

        /// <inheritdoc />
        protected override void OnPathChanged()
        {
            // Pass to base first
            base.OnPathChanged();

            // Update related
            UpdatePathProperties();
        }

        #endregion Protected Methods

        #region Public Properties

        /// <inheritdoc/>
        public string Category
        {
            get { return category; }
            set { SetProperty(ref category, value); }
        }

        /// <inheritdoc/>
        public bool IsTemplate
        {
            get { return isTemplate; }
            private set { SetProperty(ref isTemplate, value); }
        }

        /// <inheritdoc/>
        public string Name
        {
            get => Data.Header.Name;
            set => SetProperty(Data.Header.Name, value, Data, (d, v) => d.Header.Name = v);
        }

        #endregion Public Properties
    }
}