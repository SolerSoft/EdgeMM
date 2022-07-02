using BidirectionalMap;
using ModMan.Entities;
using ModMan.Serialization.Yaml;
using SharpYaml.Events;

namespace ModMan.Serialization.EdgeTX
{
    /// <summary>
    /// Converts a <see cref="LogicalSwitchFunction" /> to and from a <see cref="Scalar" />.
    /// </summary>
    public class LogicalSwitchFunctionConverter : EnumKeyConverter<LogicalSwitchFunction>
    {
        #region Constants

        private static readonly BiMap<LogicalSwitchFunction, string> map = new()
        {
            { LogicalSwitchFunction.None, "FUNC_NONE" },
            { LogicalSwitchFunction.ValueEqual,"FUNC_VEQUAL" },
            { LogicalSwitchFunction.ValueApproximately, "FUNC_VALMOSTEQUAL" },
            { LogicalSwitchFunction.ValueGreater, "FUNC_VPOS" },
            { LogicalSwitchFunction.ValueLess, "FUNC_VNEG" },
            { LogicalSwitchFunction.ValueGreaterAbsolute, "FUNC_APOS" },
            { LogicalSwitchFunction.ValueLessAbsolute, "FUNC_ANEG" },
            { LogicalSwitchFunction.And, "FUNC_AND" },
            { LogicalSwitchFunction.Or, "FUNC_OR" },
            { LogicalSwitchFunction.Xor, "FUNC_XOR" },
            { LogicalSwitchFunction.Edge, "FUNC_EDGE" },
            { LogicalSwitchFunction.SourceEqual, "FUNC_EQUAL" },
            { LogicalSwitchFunction.SourceGreater, "FUNC_GREATER" },
            { LogicalSwitchFunction.SourceLess, "FUNC_LESS" },
            { LogicalSwitchFunction.DiffGreater, "FUNC_DIFFEGREATER" },
            { LogicalSwitchFunction.DiffeGreaterAbsolute, "FUNC_ADIFFEGREATER" },
            { LogicalSwitchFunction.Timer, "FUNC_TIMER" },
            { LogicalSwitchFunction.Sticky, "FUNC_STICKY" },
        };

        #endregion Constants

        #region Public Constructors

        /// <summary>
        /// Initializes a new <see cref="LogicalSwitchFunctionConverter" />.
        /// </summary>
        public LogicalSwitchFunctionConverter() : base(map) { }

        #endregion Public Constructors
    }
}