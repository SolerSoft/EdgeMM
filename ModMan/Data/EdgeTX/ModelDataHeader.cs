using SharpYaml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Data.EdgeTX
{
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
