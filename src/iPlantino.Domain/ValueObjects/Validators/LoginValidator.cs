using FluentValidation;

namespace iPlantino.Domain.ValueObjects.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator(string propertyName = "Login")
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .OverridePropertyName(propertyName)
                .WithMessage("Please ensure you have entered the Login");

            RuleFor(x => x.Value)
                .MinimumLength(Login.MIN_SIZE)
                .OverridePropertyName(propertyName)
                .When(x => !string.IsNullOrEmpty(x.Value))
                .WithMessage($"The Login must have at least {Login.MIN_SIZE} characters");
        }
    }
}
