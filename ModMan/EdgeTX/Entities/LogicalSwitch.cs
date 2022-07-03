using ModMan.Core.Entities;
using ModMan.EdgeTX.Data;

namespace ModMan.EdgeTX.Entities
{
    /// <summary>
    /// An EdgeTX logical switch.
    /// </summary>
    public class LogicalSwitch : MappedEntity<LogicalSwitchData>, ILogicalSwitch
    {
        #region Public Constructors

        /// <inheritdoc />
        public LogicalSwitch(LogicalSwitchData data) : base(data) { }

        #endregion Public Constructors

        #region Public Properties

        /// <inheritdoc />
        public string AndSwitch
        {
            get => Data.AndSwitch;
            set => SetProperty(Data.AndSwitch, value, Data, (d, v) => d.AndSwitch = v);
        }

        /// <inheritdoc />
        public string Definition
        {
            get => Data.Definition;
            set => SetProperty(Data.Definition, value, Data, (d, v) => d.Definition = v);
        }

        /// <inheritdoc />
        public TimeSpan Delay
        {
            get => TimeSpan.FromSeconds(Data.Delay);
            set => SetProperty(Data.Delay, (float)value.TotalSeconds, Data, (d, v) => d.Duration = v);
        }

        /// <inheritdoc />
        public TimeSpan Duration
        {
            get => TimeSpan.FromSeconds(Data.Duration);
            set => SetProperty(Data.Duration, (float)value.TotalSeconds, Data, (d, v) => d.Duration = v);
        }

        /// <inheritdoc />
        public LogicalSwitchFunction Function
        {
            get => Data.Function;
            set => SetProperty(Data.Function, value, Data, (d, v) => d.Function = v);
        }

        /// <inheritdoc />
        public string Name
        {
            get => Data.Name;
            set => SetProperty(Data.Name, value, Data, (d, v) => d.Name = v);
        }

        #endregion Public Properties
    }
}