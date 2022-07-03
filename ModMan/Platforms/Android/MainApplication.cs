using Android.App;
using Android.Runtime;

namespace ModMan;

[Application]
public class MainApplication : MauiApplication
{
    #region Public Constructors

    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    #endregion Protected Methods
}