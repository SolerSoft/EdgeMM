using ModMan.Core.Entities;
using ModMan.Maui;
using ModMan.UI;

namespace ModMan;

public partial class AppShell : Shell
{
    #region Private Methods

    private void RegisterRoutes()
    {
        Router.RegisterDetail<Model, ModelPage>();
    }

    #endregion Private Methods

    #region Public Constructors

    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    #endregion Public Constructors
}