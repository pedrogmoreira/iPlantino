using iPlantino.Domain.Core.Models;

namespace iPlantino.Domain.ValueObjects
{
    public sealed class Login : ValueObject<Login>
    {
        public const int MIN_SIZE = 3;

        public Login(string value)
        {
            Value = value.ToLower();
        }

        public string Value { get; private set; }

        protected override bool EqualsCore(Login other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode() * 152;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Value) && Value.Length >= MIN_SIZE;
        }

        public static implicit operator Login(string value)
            => new Login(value);

        public override string ToString() => Value;
    }
}
