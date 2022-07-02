using SharpYaml.Events;
using SharpYaml.Serialization;
using SharpYaml.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Serialization
{
    /// <summary>
    /// Converts a <see cref="Version"/> to and from a <see cref="Scalar"/>.
    /// </summary>
    public class VersionConverter : ScalarSerializerBase, IYamlSerializableFactory
    {
        public override object ConvertFrom(ref ObjectContext context, Scalar fromScalar)
        {
            return Version.Parse(fromScalar.Value);
        }

        public override string ConvertTo(ref ObjectContext objectContext)
        {
            return ((Version)objectContext.Instance).ToString();
        }

        public IYamlSerializable TryCreate(SerializerContext context, ITypeDescriptor typeDescriptor)
        {
            return typeDescriptor.Type == typeof(Version) ? this : null;
        }
    }
}
