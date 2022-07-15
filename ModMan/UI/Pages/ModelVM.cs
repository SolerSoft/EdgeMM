using ModMan.Core.Entities;
using SolerSoft.Mvvm;

namespace ModMan.UI
{
    /// <summary>
    /// The ViewModel for <see cref="ModelPage" />.
    /// </summary>
    public class ModelVM : ViewModel
    {
        #region Private Fields

        private Model model;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the model of the <see cref="ModelVM" />.
        /// </summary>
        /// <value>
        /// The model of the <c>ModelDetailVM</c>.
        /// </value>
        public Model Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        #endregion Public Properties
    }
}