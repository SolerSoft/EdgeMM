using System.Collections.ObjectModel;
using IOPath = System.IO.Path;
using ModelCollection = ModMan.Entities.EntityCollection<ModMan.Entities.IModel, ModMan.Entities.EdgeTX.Model>;

namespace ModMan.Entities.EdgeTX
{
    /// <summary>
    /// Represents an EdgeTX profile, often stored on a SD Card.
    /// </summary>
    public class Profile : Entity, IProfile
    {
        #region Constants

        private const string MODELS_DIR = "MODELS";
        private const string TEMPLATES_DIR = "TEMPLATES";

        #endregion Constants

        #region Private Fields

        private ModelCollection models = new ModelCollection();
        private string name;
        private ModelCollection templates = new ModelCollection();

        #endregion Private Fields

        public Profile(string path)
        {
            // Validate
            if (string.IsNullOrEmpty(path)) { throw new ArgumentException(nameof(path)); }

            // Store
            Path = path;

            // Calculate
            string directory = IOPath.GetDirectoryName(path);
            ModelsPath = IOPath.Combine(directory, MODELS_DIR);
            TemplatesPath = IOPath.Combine(directory, TEMPLATES_DIR);
        }

        #region IProfile Implementation

        IEntityCollection<IModel> IProfile.Models => models;
        IEntityCollection<IModel> IProfile.Templates => templates;

        #endregion // IProfile Implementation


        #region Public Properties

        /// <summary>
        /// Gets or sets the list of models stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of models stored within the <see cref="Profile" />.
        /// </value>
        public ModelCollection Models
        {
            get { return models; }
            set { SetProperty(ref models, value); }
        }

        /// <summary>
        /// Gets the path to the model files stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The path to the model files stored within the <see cref="Profile" />.
        /// </value>
        public string ModelsPath { get; private set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        /// <value>
        /// The name of the object.
        /// </value>
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        /// <summary>
        /// Gets the path to the profile main file.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Gets or sets the list of model templates stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of model templates stored within the <see cref="Profile" />.
        /// </value>
        public ModelCollection Templates
        {
            get { return templates; }
            set { SetProperty(ref templates, value); }
        }

        /// <summary>
        /// Gets the path to the template files stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The path to the template files stored within the <see cref="Profile" />.
        /// </value>
        public string TemplatesPath { get; private set; }

        #endregion Public Properties
    }
}