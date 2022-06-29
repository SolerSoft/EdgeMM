using EdgeMM.Data;
using System.Collections.ObjectModel;

namespace EdgeMM.Entities
{
    /// <summary>
    /// Represents an EdgeTX profile, often stored on a SD Card.
    /// </summary>
    public class Profile : NamedFileObject
    {
        #region Private Fields

        private ObservableCollection<Model> models = new ObservableCollection<Model>();
        private ObservableCollection<ModelTemplate> templates = new ObservableCollection<ModelTemplate>();

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the list of models stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of models stored within the <see cref="Profile" />.
        /// </value>
        public ObservableCollection<Model> Models
        {
            get { return models; }
            set { SetProperty(ref models, value); }
        }

        /// <summary>
        /// Gets or sets the list of model templates stored within the <see cref="Profile" />.
        /// </summary>
        /// <value>
        /// The list of model templates stored within the <see cref="Profile" />.
        /// </value>
        public ObservableCollection<ModelTemplate> Templates
        {
            get { return templates; }
            set { SetProperty(ref templates, value); }
        }

        #endregion Public Properties
    }
}