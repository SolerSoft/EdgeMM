using ModMan.Core.Entities;
using SolerSoft.Mvvm;

namespace ModMan.UI;

[QueryProperty(nameof(Model), "model")]
public partial class ModelPage : ViewPage<ModelVM>
{
    #region Public Constructors

    /// <summary>
    /// Initializes a new <see cref="ModelPage" />.
    /// </summary>
    public ModelPage()
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