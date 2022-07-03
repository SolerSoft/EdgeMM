namespace ModMan.Core.Entities
{
    /// <summary>
    /// Describes the commonly supported logical switch functions.
    /// </summary>
    public enum LogicalSwitchFunction
    {
        /// <summary>
        /// Indicates that the switch has not been configured and is disabled.
        /// </summary>
        /// <remarks>
        /// Often represented as '---'.
        /// </remarks>
        None,

        /// <summary>
        /// Check if the value of A (a selectable source) is equal to X (a chosen value).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a=x'.
        /// </remarks>
        ValueEqual,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is approximately equal to X (a chosen value).
        /// </summary>
        /// <remarks>
        /// <para>Often represented as 'a~x'.</para>
        /// <para>"Approximately" generally means + or – 0.9 from the desired value.</para>
        /// </remarks>
        ValueApproximately,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is greater than X (a chosen value).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a&gt;x'.
        /// </remarks>
        ValueGreater,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is less than X (a chosen value).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a&lt;x'.
        /// </remarks>
        ValueLess,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is greater than X (a chosen value).
        /// </summary>
        /// <remarks>
        /// Often represented as '|a|&gt;x'.
        /// </remarks>
        ValueGreaterAbsolute,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is less than X (a chosen value).
        /// </summary>
        /// <remarks>
        /// Often represented as '|a|&lt;x'.
        /// </remarks>
        ValueLessAbsolute,

        /// <summary>
        /// Checks that BOTH switches V1 AND V2 are true.
        /// </summary>
        /// <remarks>
        /// Often represented as 'AND'.
        /// </remarks>
        And,

        /// <summary>
        /// Checks if either switch V1 or V2 are true.
        /// </summary>
        /// <remarks>
        /// Often represented as 'OR'.
        /// </remarks>
        Or,

        /// <summary>
        /// Checks if either but NOT BOTH V1 and V2 are true.
        /// </summary>
        /// <remarks>
        /// Often represented as 'XOR'.
        /// </remarks>
        Xor,

        /// <summary>
        /// A momentary switch which can be activated by another switch depending on the length of time that switch is "true".
        /// </summary>
        /// <remarks>
        /// Often represented as 'Edge'.
        /// </remarks>
        Edge,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is equal to B (a different selectable source).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a=b'.
        /// </remarks>
        SourceEqual,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is greater than B (a different selectable source).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a&gt;b'.
        /// </remarks>
        SourceGreater,

        /// <summary>
        /// Checks to see if the value of A (a selectable source) is less than B (a different selectable source).
        /// </summary>
        /// <remarks>
        /// Often represented as 'a&lt;b'.
        /// </remarks>
        SourceLess,

        /// <summary>
        /// Checks to see if the Delta (change in value) of A (a selectable source) is greater than or equal to
        /// specified value X.
        /// </summary>
        /// <remarks>
        /// Often represented as 'd&gt;=x'.
        /// </remarks>
        DiffGreater,

        /// <summary>
        /// Checks to see if the absolute Delta (change in value) of A (a selectable source) is greater than or equal to
        /// specified value X.
        /// </summary>
        /// <remarks>
        /// Often represented as '|d|&gt;=x'.
        /// </remarks>
        DiffeGreaterAbsolute,

        /// <summary>
        /// Causes the switch to turn ON or OFF at specified intervals.
        /// </summary>
        /// <remarks>
        /// <para>Often represented as 'Timer'.</para>
        /// <para>
        /// V1: Is the on time.
        /// V2: the off time.
        /// </para>
        /// </remarks>
        Timer,

        /// <summary>
        /// Causes the switch to act like a toggle.
        /// </summary>
        /// <remarks>
        /// <para>Often represented as 'Timer'.</para>
        /// <para>
        /// V1: Is the switch to turn On.
        /// V2: Is the switch to turn Off.
        /// </para>
        /// </remarks>
        Sticky,
    }

    /// <summary>
    /// An EdgeTX logical switch.
    /// </summary>
    public class LogicalSwitch : NamedEntity
    {
        #region Private Fields

        private string andSwitch;
        private string definition;
        private TimeSpan delay;
        private TimeSpan duration;
        private LogicalSwitchFunction function;

        #endregion Private Fields

        #region Public Properties

        public string AndSwitch
        {
            get => andSwitch;
            set => SetProperty(ref andSwitch, value);
        }

        public string Definition
        {
            get => definition;
            set => SetProperty(ref definition, value);
        }

        /// <summary>
        /// Gets or sets the a delay before the switch comes on, once the conditions are true.
        /// </summary>
        /// <value>
        /// The a delay before the switch comes on, once the conditions are true.
        /// </value>
        public TimeSpan Delay
        {
            get => delay;
            set => SetProperty(ref delay, value);
        }

        /// <summary>
        /// Gets or sets the length of time the switch will stay ON.
        /// </summary>
        /// <value>
        /// The length of time the switch will stay ON.
        /// </value>
        /// <remarks>
        /// If set to 0.0, the switch will remain on until the conditions make the switch off. Any other setting will
        /// cause the switch to go off after the number of seconds selected, even if the conditions remain true.
        /// </remarks>
        public TimeSpan Duration
        {
            get => duration;
            set => SetProperty(ref duration, value);
        }

        /// <summary>
        /// Gets or sets the function that will be used to evaluate whether the logical switch is on.
        /// </summary>
        /// <value>
        /// The function that will be used to evaluate whether the logical switch is on.
        /// </value>
        public LogicalSwitchFunction Function
        {
            get => function;
            set => SetProperty(ref function, value);
        }

        #endregion Public Properties
    }
}