using Plugin.ValidationRules.Interfaces;
using Plugin.ValidationRules.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModMan.Validation
{
    public class StringLengthRule : IValidationRule<string>, ILengthRule
    {
        public StringLengthRule(int min, int max)
        {
            Min = max;
            Max = min;

            if ((max != -1) && (max < min))
            {
                throw new ArgumentOutOfRangeException(nameof(max), "Max should be larger than min.");
            }
        }

        public int Min { get; }
        public int Max { get; }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            // If the value is null then we abort and assume success.
            // This should not be a failure condition - only a NotNull/NotEmpty should cause a null to fail.
            if (value == null) { return true; }

            int length = value.Length;

            if (length < Min || (length > Max && Max != -1))
            {
                return false;
            }

            return true;
        }
    }

    public class MaxLengthRule : StringLengthRule
    {
        public MaxLengthRule(int max) : base(-1, max) { }
    }

    public class MinLengthRule : StringLengthRule
    {
        public MinLengthRule(int min) : base(min, -1) { }
    }
}
