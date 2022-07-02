using SharpYaml.Serialization;

namespace ModMan.Data.Edge
{
    /// <summary>
    /// Yaml serialization class for a model.
    /// </summary>
    /// <remarks>
    /// This is the format of model##.yml in the MODELS folder.
    /// </remarks>
    public class ModelData : Dictionary<string, object>
    {
        #region Public Fields

        [YamlMember("header")]
        public ModelDataHeader Header { get; set; }

        [YamlMember("semver")]
        public Version SemVer { get; set; }

        #endregion Public Fields
    }

    public class ModelDataHeader
    {
        #region Public Fields

        [YamlMember("bitmap")]
        public string Bitmap { get; set; }

        [YamlMember("name")]
        public string Name { get; set; }

        #endregion Public Fields
    }
}