namespace SolerSoft.Mvvm;

/// <summary>
/// Base class Views with a ViewModel.
/// </summary>
/// <typeparam name="TViewModel">
/// The type of the ViewModel.
/// </typeparam>
public class ViewPage<TViewModel> : ContentPage where TViewModel : ViewModel, new()
{
    #region Private Fields

    private TViewModel viewModel = new TViewModel();

    #endregion Private Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new ViewPage.
    /// </summary>
    public ViewPage()
    {
        BindingContext = viewModel;
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the ViewModel for the view.
    /// </summary>
    public TViewModel ViewModel
    {
        get => viewModel;
        set
        {
            viewModel = value;
            BindingContext = viewModel;
            OnPropertyChanged();
        }
    }

    #endregion Public Properties
}