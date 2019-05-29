using iPlantino.Authentication.Models;
using FluentValidation;

namespace iPlantino.Authentication
{
    internal class AuthenticateUserValidations : AbstractValidator<AuthenticateUser>
    {
        private const int PASSWORD_MINIMUM_SIZE = 6;
        private const int LOGIN_MINIMUM_SIZE = 3;

        public AuthenticateUserValidations()
        {
            ValidateLogin();
            ValidatePassword();
        }

        protected void ValidateLogin()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("O Login é obrigatório.");

            RuleFor(x => x.Login)
                .MinimumLength(LOGIN_MINIMUM_SIZE)
                .WithMessage($"O Login tem que ter {LOGIN_MINIMUM_SIZE} ou mais caracteres.");
        }

        protected void ValidatePassword()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A Senha é obrigatória.");

            RuleFor(x => x.Password)
                .MinimumLength(PASSWORD_MINIMUM_SIZE)
                .WithMessage($"A Senha tem que ter {PASSWORD_MINIMUM_SIZE} ou mais caracteres.");
        }
    }
}