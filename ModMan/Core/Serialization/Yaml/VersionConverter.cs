using SharpYaml.Events;
using SharpYaml.Serialization;
using SharpYaml.Serialization.Serializers;

namespace ModMan.Core.Serialization.Yaml
{
    /// <summary>
    /// Converts a <see cref="Version" /> to and from a <see cref="Scalar" />.
    /// </summary>
    public class VersionConverter : ScalarSerializerBase, IYamlSerializableFactory
    {
        #region Public Methods

        /// <inheritdoc />
        public override object ConvertFrom(ref ObjectContext context, Scalar fromScalar)
        {
            return Version.Parse(fromScalar.Value);
        }

        /// <inheritdoc />
        public override string ConvertTo(ref ObjectContext objectContext)
        {
            return ((Version)objectContext.Instance).ToString();
        }

        /// <inheritdoc />
        public IYamlSerializable TryCreate(SerializerContext context, ITypeDescriptor typeDescriptor)
        {
            return typeDescriptor.Type == typeof(Version) ? this : null;
        }

        #endregion Public Methods
    }
}