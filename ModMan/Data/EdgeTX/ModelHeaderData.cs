using SharpYaml.Serialization;

namespace ModMan.Data.EdgeTX
{
    /// <summary>
    /// The header data for an EdgeTX model.
    /// </summary>
    public class ModelHeaderData : Expando
    {
        #region Public Properties

        [YamlMember("bitmap")] // Order=1
        public string Bitmap { get; set; }

        [YamlMember("name")] // Order=0
        public string Name { get; set; }

        #endregion Public Properties
    }
}