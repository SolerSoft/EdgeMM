using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Data.EdgeTX
{
    /// <summary>
    /// A base class for EdgeTX data classes that are serialized with Yaml.
    /// </summary>
    public class Expando : Dictionary<string, object>
    {
    }
}
