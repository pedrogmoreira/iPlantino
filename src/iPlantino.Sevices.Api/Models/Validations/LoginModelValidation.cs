using FluentValidation;

namespace iPlantino.Services.Api.Models.Validations
{
    public class LoginModelValidation : AbstractValidator<LoginModel>
    {
        private const int PASSWORD_MINIMUM_SIZE = 6;
        private const int LOGIN_MINIMUM_SIZE = 3;

        public LoginModelValidation()
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
                .When(x => !string.IsNullOrEmpty(x.Login))
                .WithMessage($"O Login tem que ter {LOGIN_MINIMUM_SIZE} ou mais caracteres.");
        }

        protected void ValidatePassword()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A Senha é obrigatória.");

            RuleFor(x => x.Password)
                .MinimumLength(PASSWORD_MINIMUM_SIZE)
                .When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage($"A Senha tem que ter {PASSWORD_MINIMUM_SIZE} ou mais caracteres.");
        }
    }
}