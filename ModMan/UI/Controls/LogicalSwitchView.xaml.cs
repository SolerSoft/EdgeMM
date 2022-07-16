namespace ModMan.UI;

public partial class LogicalSwitchView : ContentView
{
    #region Public Fields

    /// <summary>
    /// Identifies the <see cref="Description" /> bindable property.
    /// </summary>
    public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description", typeof(string), typeof(LogicalSwitchView), string.Empty);

    /// <summary>
    /// Identifies the <see cref="Name" /> bindable property.
    /// </summary>
    public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(LogicalSwitchView), string.Empty);

    #endregion Public Fields

    #region Public Constructors

    /// <summary>
    /// Initializes a new <see cref="LogicalSwitchView" />.
    /// </summary>
    public LogicalSwitchView()
    {
        InitializeComponent();
    }

    #endregion Public Constructors

    #region Public Properties

    /// <summary>
    /// Gets or sets the Description of the <see cref="LogicalSwitchView" />. This is a bindable property.
    /// </summary>
    /// <value>
    /// The Description of the <see cref="LogicalSwitchView" />.
    /// </value>
    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    /// <summary>
    /// Gets or sets the Name of the <see cref="LogicalSwitchView" />. This is a bindable property.
    /// </summary>
    /// <value>
    /// The Name of the <see cref="LogicalSwitchView" />.
    /// </value>
    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    #endregion Public Properties
}