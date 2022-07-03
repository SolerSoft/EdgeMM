using BidirectionalMap;
using SharpYaml.Events;
using SharpYaml.Serialization;
using SharpYaml.Serialization.Serializers;

namespace ModMan.Core.Serialization.Yaml
{
    /// <summary>
    /// Converts an enum to and from a <see cref="Scalar" /> key value.
    /// </summary>
    public class EnumKeyConverter<TEnum> : ScalarSerializerBase, IYamlSerializableFactory where TEnum : Enum
    {
        #region Private Fields

        private BiMap<TEnum, string> map;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes the converter with the specified map.
        /// </summary>
        /// <param name="map">
        /// A bidirectional map of enum and key.
        /// </param>
        public EnumKeyConverter(BiMap<TEnum, string> map)
        {
            // Validate
            if (map == null) { throw new ArgumentNullException(nameof(map)); }

            // Store
            this.map = map;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <inheritdoc />
        public override object ConvertFrom(ref ObjectContext context, Scalar fromScalar)
        {
            // Map in reverse (key to enum)
            return map.Reverse[fromScalar.Value];
        }

        /// <inheritdoc />
        public override string ConvertTo(ref ObjectContext objectContext)
        {
            // Get the enum value
            TEnum value = ((TEnum)objectContext.Instance);

            // Map forward (enum to key)
            return map.Forward[value];
        }

        /// <inheritdoc />
        public IYamlSerializable TryCreate(SerializerContext context, ITypeDescriptor typeDescriptor)
        {
            return typeDescriptor.Type == typeof(TEnum) ? this : null;
        }

        #endregion Public Methods
    }
}