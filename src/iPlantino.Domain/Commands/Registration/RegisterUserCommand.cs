using iPlantino.Domain.Validations.Registration;
using MediatR;
using System;
using System.Threading.Tasks;

namespace iPlantino.Domain.Commands.Registration
{
    public class RegisterUserCommand : UserCommand, IRequest
    {
        public RegisterUserCommand(string name, string login, string password, string passwordConfirmation, string email)
        {
            Id = Guid.NewGuid();
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Login = login.ToLower();
            Name = name;
            Email = email;
        }

        public override async Task<bool> IsValid()
        {
            ValidationResult = await new RegisterUserValidation().ValidateAsync(this);
            return ValidationResult.IsValid;
        }
    }
}
