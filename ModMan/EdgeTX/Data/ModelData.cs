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

        [YamlMember("header", 1)]
        public ModelHeaderData Header { get; set; }

        [YamlMember("logicalSw", 19)]
        public SortedDictionary<int, LogicalSwitchData> LogicalSwitches { get; set; }

        [YamlMember("customFn", 20)]
        public SortedDictionary<int, SpecialFunctionData> SpecialFunctions { get; set; }

        [YamlIgnore]
        public string Path { get; set; }

        [YamlMember("semver", 0)]
        public Version SemVer { get; set; }

        #endregion Public Properties
    }
}