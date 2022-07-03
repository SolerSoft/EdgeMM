using ModMan.Core.Entities;
using ModMan.Core.Serialization.Yaml;
using SharpYaml.Serialization;

namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Data for an EdgeTX logical switch.
    /// </summary>
    /// <remarks>
    /// See <see href="http://open-txu.org/home/continuing-education/logical-switch-functions/"> Logical Switch Functions
    /// </see> for more information.
    /// </remarks>
    public class LogicalSwitchData : Expando
    {
        #region Public Properties

        [YamlMember("andsw")] // Order=4
        public string AndSwitch { get; set; }

        /// <summary>
        /// A comment about the switch.
        /// </summary>
        /// <remarks>
        /// Note that EdgeTX does not currently support comments, but since it's yaml we can extend it.
        /// </remarks>
        [YamlMember("comment")] // Order=1
        public string Comment { get; set; }

        [YamlMember("def")] // Order=3
        public string Definition { get; set; }

        /// <summary>
        /// The a delay before the switch comes on once the conditions are true.
        /// </summary>
        [YamlMember("delay")] // Order=5
        public TimeSpan Delay { get; set; }

        /// <summary>
        /// The length of time the switch will stay ON. If set to 0.0, the switch will remain on until the conditions
        /// make the switch off. Any other setting will cause the switch to go off after the number of seconds selected,
        /// even if the conditions remain true.
        /// </summary>
        [YamlMember("duration")] // Order=6
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// The function that will be used to evaluate whether the switch is on.
        /// </summary>
        [YamlMember("func")] // Order=2
        public LogicalSwitchFunction Function { get; set; }

        /// <summary>
        /// The name of the switch.
        /// </summary>
        /// <remarks>
        /// Note that EdgeTX does not currently support this, but since it's yaml we can add it.
        /// </remarks>
        [YamlMember("name")] // Order=0
        public string Name { get; set; }

        #endregion Public Properties
    }
}