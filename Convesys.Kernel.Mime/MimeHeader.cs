using System;

namespace Convesys.Kernel.Mime
{
    public class MimeHeader
    {
        public MimeHeader(string field, string value)
        {
            if (string.IsNullOrEmpty(field)) throw new ArgumentException($"{nameof(field)} cannot be Null or Empty");

            Field = field;
            Value = value;
        }

        public string Field { get; }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            return obj is MimeHeader header && Equals(header);
        }

        private bool Equals(MimeHeader other)
        {
            return string.Equals(Field, other.Field) && string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Field != null ? Field.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}
