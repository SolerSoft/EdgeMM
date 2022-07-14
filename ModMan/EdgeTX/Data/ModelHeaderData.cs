using ModMan.Core.Serialization.Yaml;
using SharpYaml.Serialization;

namespace ModMan.EdgeTX.Data
{
    /// <summary>
    /// The header data for an EdgeTX model.
    /// </summary>
    public class ModelHeaderData : Expando
    {
        #region Public Properties

        [YamlMember("bitmap", 2)]
        public string Bitmap { get; set; }
        
        [YamlMember("comment", 1)]
        public string Comment { get; set; }

        [YamlMember("name", 0)]
        public string Name { get; set; }

        #endregion Public Properties
    }
}