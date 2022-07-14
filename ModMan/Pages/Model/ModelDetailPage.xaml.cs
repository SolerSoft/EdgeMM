using ModMan.Core.Entities;
using ModMan.ViewModels;
using SolerSoft.Mvvm;

namespace ModMan.Pages;

[QueryProperty(nameof(Model), "model")]
public partial class ModelDetailPage : ViewPage<ModelDetailVM>
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new <see cref="ModelDetailPage" />.
    /// </summary>
    public ModelDetailPage()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the <see cref="Model" />.
    /// </summary>
    public Model Model { get => ViewModel.Model; set => ViewModel.Model = value; }

    #endregion Public Properties
}