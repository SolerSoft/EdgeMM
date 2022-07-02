using SharpYaml.Serialization;

namespace ModMan.Data.EdgeTX
{
    /// <summary>
    /// Data for an EdgeTX logical switch.
    /// </summary>
    /// See
    /// <see href="http://open-txu.org/home/continuing-education/logical-switch-functions/">
    /// Logical Switch Functions
    /// </see>
    /// for more information.
    public class LogicalSwitchData : Expando
    {
        #region Public Properties

        [YamlMember("andsw")] // Order=3
        public string AndSwitch { get; set; }

        [YamlMember("def")] // Order=2
        public string Definition { get; set; }

        /// <summary>
        /// The a delay before the switch comes on once the conditions are true.
        /// </summary>
        [YamlMember("delay")] // Order=4
        public float Delay { get; set; }

        /// <summary>
        /// The length of time the switch will stay ON. If set to 0.0, the switch will remain on until the conditions
        /// make the switch off. Any other setting will cause the switch to go off after the number of seconds selected,
        /// even if the conditions remain true.
        /// </summary>
        [YamlMember("duration")] // Order=5
        public float Duration { get; set; }

        [YamlMember("func")] // Order=1
        public string Function { get; set; }

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