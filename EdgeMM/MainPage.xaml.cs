using EdgeMM.Managers;

namespace EdgeMM;

public partial class MainPage : ContentPage
{
    #region Private Fields

    private int count = 0;

    #endregion Private Fields

    #region Public Constructors

    public MainPage()
    {
        InitializeComponent();
        var t = LoadDataAsync();
    }

    #endregion Public Constructors

    #region Private Methods

    private async Task LoadDataAsync()
    {
        var manager = new ProfileManager();

        var prof = await manager.LoadProfileAsync(@"C:\tmp\SD\edgetx.sdcard.version");
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    #endregion Private Methods
}