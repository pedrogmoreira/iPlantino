using iPlantino.Domain.Core.Models;

namespace iPlantino.Domain.ValueObjects
{
    public sealed class Email : ValueObject<Email>
    {
        public Email(string address)
        {
            Address = address.ToLower();
        }

        public string Address { get; private set; }

        protected override bool EqualsCore(Email other)
        {
            return Address == other.Address;
        }

        protected override int GetHashCodeCore()
        {
            return Address.GetHashCode() * 254;
        }

        public static implicit operator Email(string value)
           => new Email(value);

        public override string ToString() => Address;
    }
}
