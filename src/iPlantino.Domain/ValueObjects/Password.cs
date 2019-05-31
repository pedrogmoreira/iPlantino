using iPlantino.Domain.Core.Models;

namespace iPlantino.Domain.ValueObjects
{
    public sealed class Password : ValueObject<Password>
    {
        public static int RequiredLengh = 6;

        public Password(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        protected override bool EqualsCore(Password other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode() * 254;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Value) && Value.Length >= RequiredLengh;
        }

        public static implicit operator Password(string value)
            => new Password(value);

        public override string ToString() => Value;

    }
}
