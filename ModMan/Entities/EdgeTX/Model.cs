using ModMan.Data.EdgeTX;
using System.Collections.ObjectModel;

namespace ModMan.Entities.EdgeTX
{
    /// <summary>
    /// Represents an EdgeTX RC model.
    /// </summary>
    public class Model : MappedEntity<ModelData>, IModel
    {
        #region Constants

        private const string TEMPLATES_DIR = "TEMPLATES";

        #endregion Constants

        #region Private Fields

        private string category;
        private bool isTemplate;
        private string path;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="Model" /> with the specified backing data.
        /// </summary>
        /// <param name="path">
        /// The path to the model file.
        /// </param>
        /// <param name="modelData">
        /// The backing data for the model.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="modelData" /> is null.
        /// </exception>
        public Model(string path, ModelData modelData) : base(modelData) 
        {
            // Validate
            if (string.IsNullOrEmpty(path)) { throw new ArgumentException(nameof(path)); }

            // Store
            this.path = path;

            // Calculate
            isTemplate = path.Contains(TEMPLATES_DIR);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <inheritdoc/>
        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        /// <inheritdoc/>
        public bool IsTemplate => isTemplate;

        /// <inheritdoc/>
        public string Name
        {
            get => Data.Header.Name;
            set => SetProperty(Data.Header.Name, value, Data, (d, v) => d.Header.Name = v);
        }

        /// <summary>
        /// Gets the path to the model file.
        /// </summary>
        public string Path => path;

        #endregion Public Properties
    }
}