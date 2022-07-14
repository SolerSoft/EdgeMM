using ModMan.Core.Entities;
using ModMan.Pages;
using SolerSoft.Mvvm;

namespace ModMan.ViewModels
{
    /// <summary>
    /// The ViewModel for <see cref="ModelDetailPage" />.
    /// </summary>
    public class ModelDetailVM : ViewModel
    {
        #region Private Fields

        private Model model;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the model of the <see cref="ModelDetailVM" />.
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