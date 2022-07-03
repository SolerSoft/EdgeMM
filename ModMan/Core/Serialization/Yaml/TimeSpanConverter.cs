using SharpYaml.Events;
using SharpYaml.Serialization;
using SharpYaml.Serialization.Serializers;

namespace ModMan.Core.Serialization.Yaml
{
    /// <summary>
    /// Converts a <see cref="TimeSpanConverter" /> to and from a <see cref="Scalar" />.
    /// </summary>
    public class TimeSpanConverter : ScalarSerializerBase, IYamlSerializableFactory
    {
        #region Public Methods

        /// <inheritdoc />
        public override object ConvertFrom(ref ObjectContext context, Scalar fromScalar)
        {
            // Try to get seconds
            double seconds;
            Double.TryParse(fromScalar.Value, out seconds);

            // Return as TimeSpan
            return TimeSpan.FromSeconds(seconds);
        }

        /// <inheritdoc />
        public override string ConvertTo(ref ObjectContext objectContext)
        {
            // Get the TimeSpan
            TimeSpan span = (TimeSpan)objectContext.Instance;

            // Convert to seconds as a number
            return span.TotalSeconds.ToString("0.##");
        }

        /// <inheritdoc />
        public IYamlSerializable TryCreate(SerializerContext context, ITypeDescriptor typeDescriptor)
        {
            return typeDescriptor.Type == typeof(TimeSpan) ? this : null;
        }

        #endregion Public Methods
    }
}