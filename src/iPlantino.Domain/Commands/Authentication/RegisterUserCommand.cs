using iPlantino.Domain.Validations.Authentication;
using MediatR;
using System.Threading.Tasks;

namespace iPlantino.Domain.Commands.Authentication
{
    public class RegisterUserCommand : UserCommand, IRequest
    {
        public RegisterUserCommand(string name, string login, string password, string passwordConfirmation, string telephone, string email)
        {
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Login = login.ToLower();
            Name = name;
            Telephone = telephone;
            Email = email;
        }

        public override async Task<bool> IsValid()
        {
            ValidationResult = await new RegisterUserValidation().ValidateAsync(this);
            return ValidationResult.IsValid;
        }
    }
}
