using SharpYaml.Serialization;

namespace EdgeMM.Data
{
    /// <summary>
    /// Yaml serialization class for a model.
    /// </summary>
    /// <remarks>
    /// This is the item format of models.yml in the MODELS folder.
    /// </remarks>
    internal class ModelData
    {
        #region Public Fields

        [YamlMember("filename")]
        public string FileName;

        [YamlMember("name")]
        public string Name;

        #endregion Public Fields
    }
}