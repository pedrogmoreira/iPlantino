using iPlantino.Domain.Commands.Registration;

namespace iPlantino.Domain.Validations.Registration
{
    public class RegisterUserValidation : UserValidation<RegisterUserCommand>
    {
        public RegisterUserValidation()
        {
            ValidateName();
            ValidateLogin();
            ValidateEmail();
            ValidatePassord();
            ValidatePassordConfirmation();
        }
    }
}
