using ModMan.Entities;
using SharpYaml.Events;
using SharpYaml.Serialization;
using SharpYaml.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Serialization.EdgeTX
{
    /// <summary>
    /// Converts a <see cref="LogicalSwitchFunction"/> to and from a <see cref="Scalar"/>.
    /// </summary>
    public class LogicalSwitchFunctionConverter : ScalarSerializerBase, IYamlSerializableFactory
    {
        private const string FUNC_NONE = "FUNC_NONE";
        private const string FUNC_VEQUAL = "FUNC_VEQUAL";
        private const string FUNC_VALMOSTEQUAL = "FUNC_VALMOSTEQUAL";
        private const string FUNC_VPOS = "FUNC_VPOS";
        private const string FUNC_VNEG = "FUNC_VNEG";
        private const string FUNC_APOS = "FUNC_APOS";
        private const string FUNC_ANEG = "FUNC_ANEG";
        private const string FUNC_AND = "FUNC_AND";
        private const string FUNC_OR = "FUNC_OR";
        private const string FUNC_XOR = "FUNC_XOR";
        private const string FUNC_EDGE = "FUNC_EDGE";
        private const string FUNC_EQUAL = "FUNC_EQUAL";
        private const string FUNC_GREATER = "FUNC_GREATER";
        private const string FUNC_LESS = "FUNC_LESS";
        private const string FUNC_DIFFEGREATER = "FUNC_DIFFEGREATER";
        private const string FUNC_ADIFFEGREATER = "FUNC_ADIFFEGREATER";
        private const string FUNC_TIMER = "FUNC_TIMER";
        private const string FUNC_STICKY = "FUNC_STICKY";

        public override object ConvertFrom(ref ObjectContext context, Scalar fromScalar)
        {
            switch (fromScalar.Value)
            {
                case FUNC_NONE:
                    return LogicalSwitchFunction.None;

                case FUNC_VEQUAL:
                    return LogicalSwitchFunction.ValueEqual;

                case FUNC_VALMOSTEQUAL:
                    return LogicalSwitchFunction.ValueApproximately;

                case FUNC_VPOS:
                    return LogicalSwitchFunction.ValueGreater;

                case FUNC_VNEG:
                    return LogicalSwitchFunction.ValueLess;

                case FUNC_APOS:
                    return LogicalSwitchFunction.ValueGreaterAbsolute;

                case FUNC_ANEG:
                    return LogicalSwitchFunction.ValueLessAbsolute;

                case FUNC_AND:
                    return LogicalSwitchFunction.And;

                case FUNC_OR:
                    return LogicalSwitchFunction.Or;

                case FUNC_XOR:
                    return LogicalSwitchFunction.Xor;

                case FUNC_EDGE:
                    return LogicalSwitchFunction.Edge;

                case FUNC_EQUAL:
                    return LogicalSwitchFunction.SourceEqual;

                case FUNC_GREATER:
                    return LogicalSwitchFunction.SourceGreater;

                case FUNC_LESS:
                    return LogicalSwitchFunction.SourceLess;

                case FUNC_DIFFEGREATER:
                    return LogicalSwitchFunction.DiffGreater;

                case FUNC_ADIFFEGREATER:
                    return LogicalSwitchFunction.DiffeGreaterAbsolute;

                case FUNC_TIMER:
                    return LogicalSwitchFunction.Timer;

                case FUNC_STICKY:
                    return LogicalSwitchFunction.Sticky;

                default:
                    throw new UnexpectedBranchException(fromScalar.Value);
            }
        }

        public override string ConvertTo(ref ObjectContext objectContext)
        {
            // return ((Version)objectContext.Instance).ToString();

            switch ((LogicalSwitchFunction)objectContext.Instance)
            {
                case LogicalSwitchFunction.None:
                    return FUNC_NONE;

                case LogicalSwitchFunction.ValueEqual:
                    return FUNC_VEQUAL;

                case LogicalSwitchFunction.ValueApproximately:
                    return FUNC_VALMOSTEQUAL;

                case LogicalSwitchFunction.ValueGreater:
                    return FUNC_VPOS;

                case LogicalSwitchFunction.ValueLess:
                    return FUNC_VNEG;

                case LogicalSwitchFunction.ValueGreaterAbsolute:
                    return FUNC_APOS;

                case LogicalSwitchFunction.ValueLessAbsolute:
                    return FUNC_ANEG;

                case LogicalSwitchFunction.And:
                    return FUNC_AND;

                case LogicalSwitchFunction.Or:
                    return FUNC_OR;

                case LogicalSwitchFunction.Xor:
                    return FUNC_XOR;

                case LogicalSwitchFunction.Edge:
                    return FUNC_EDGE;

                case LogicalSwitchFunction.SourceEqual:
                    return FUNC_EQUAL;

                case LogicalSwitchFunction.SourceGreater:
                    return FUNC_GREATER;

                case LogicalSwitchFunction.SourceLess:
                    return FUNC_LESS;

                case LogicalSwitchFunction.DiffGreater:
                    return FUNC_DIFFEGREATER;

                case LogicalSwitchFunction.DiffeGreaterAbsolute:
                    return FUNC_ADIFFEGREATER;

                case LogicalSwitchFunction.Timer:
                    return FUNC_TIMER;

                case LogicalSwitchFunction.Sticky:
                    return FUNC_STICKY;

                default:
                    throw new UnexpectedBranchException(objectContext.Instance);
            }
        }

        public IYamlSerializable TryCreate(SerializerContext context, ITypeDescriptor typeDescriptor)
        {
            return typeDescriptor.Type == typeof(LogicalSwitchFunction) ? this : null;
        }
    }
}
