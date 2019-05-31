using iPlantino.Domain.Commands.Authentication;
using FluentValidation;
using iPlantino.Domain.ValueObjects.Validators;

namespace iPlantino.Domain.Validations.Authentication
{
    public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateLogin()
        {
            RuleFor(c => c.Login)
                .SetValidator(new LoginValidator());
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .SetValidator(new EmailValidator());
        }

        protected void ValidatePassord()
        {
            RuleFor(c => c.Password)
                .SetValidator(new PasswordValidator());
        }

        protected void ValidatePassordConfirmation()
        {
            RuleFor(x => x.PasswordConfirmation)
                .Equal(x => x.Password)
                .WithMessage("Password Confirmation must be equal to Password");
        }
    }
}
