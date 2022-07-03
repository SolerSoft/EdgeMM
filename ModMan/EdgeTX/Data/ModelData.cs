using ModMan.Core.Serialization.Yaml;
using SharpYaml.Serialization;

namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// Yaml serialization class for a model.
    /// </summary>
    /// <remarks>
    /// This is the format of model##.yml in the MODELS folder.
    /// </remarks>
    public class ModelData : Expando
    {
        #region Public Properties

        [YamlMember("header")] // Order=1
        public ModelHeaderData Header { get; set; }

        [YamlMember("logicalSw")]// Order=5
        public SortedDictionary<int, LogicalSwitchData> LogicalSwitches { get; set; }

        [YamlMember("customFn")]// Order=5
        public SortedDictionary<int, SpecialFunctionData> SpecialFunctions { get; set; }

        [YamlIgnore]
        public string Path { get; set; }

        [YamlMember("semver")] // Order=0
        public Version SemVer { get; set; }

        #endregion Public Properties
    }
}