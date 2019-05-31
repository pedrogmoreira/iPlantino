using FluentValidation;

namespace iPlantino.Domain.ValueObjects.Validators
{
    public class PasswordValidator : AbstractValidator<Password>
    {
        public PasswordValidator(string propertyName = "Password")
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .OverridePropertyName("Password")
                .WithMessage("Please ensure you have entered the Password");

            RuleFor(x => x.Value)
                .MinimumLength(Password.RequiredLengh)
                .OverridePropertyName(propertyName)
                .When(x => !string.IsNullOrEmpty(x.Value))
                .WithMessage($"The Password must have at least {Password.RequiredLengh} characters");
        }
    }
}
