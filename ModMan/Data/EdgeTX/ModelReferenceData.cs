using SharpYaml.Serialization;

namespace ModMan.Data.EdgeTX
{
    /// <summary>
    /// Yaml serialization class to select a model.
    /// </summary>
    /// <remarks>
    /// This is the item format of models.yml in the MODELS folder.
    /// </remarks>
    public class ModelReferenceData : Expando
    {
        #region Public Properties

        [YamlIgnore]
        public string Category { get; set; }

        [YamlMember("filename")] // Order=0
        public string FileName { get; set; }

        [YamlMember("name")] // Order=1
        public string Name { get; set; }

        #endregion Public Properties
    }
}