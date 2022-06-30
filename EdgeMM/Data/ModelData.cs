using SharpYaml.Serialization;

namespace EdgeMM.Data
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
        public ModelDataHeader Header;

        [YamlMember("semver")]
        public string SemVer;

        #endregion Public Fields
    }

    public class ModelDataHeader
    {
        #region Public Fields

        [YamlMember("bitmap")]
        public string Bitmap;

        [YamlMember("name")]
        public string Name;

        #endregion Public Fields
    }
}