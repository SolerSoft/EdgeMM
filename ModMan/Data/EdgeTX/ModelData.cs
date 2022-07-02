using SharpYaml.Serialization;

namespace ModMan.Data.EdgeTX
{
    /// <summary>
    /// Yaml serialization class for a model.
    /// </summary>
    /// <remarks>
    /// This is the format of model##.yml in the MODELS folder.
    /// </remarks>
    public class ModelData : Expando
    {
        #region Public Fields

        [YamlMember("header")]
        public ModelHeaderData Header { get; set; }

        [YamlMember("semver")]
        public Version SemVer { get; set; }

        [YamlMember("logicalSw")]
        public Dictionary<int, LogicalSwitchData> LogicalSwitches { get; set; }

        #endregion Public Fields
    }
}