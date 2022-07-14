using ModMan.Pages;

namespace ModMan;

public partial class AppShell : Shell
{
    #region Private Methods

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("model/detail", typeof(ModelDetailPage));
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