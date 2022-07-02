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
        public ModelDataHeader Header { get; set; }

        [YamlMember("semver")]
        public Version SemVer { get; set; }

        #endregion Public Fields
    }
}