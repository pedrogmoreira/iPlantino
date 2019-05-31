using iPlantino.Domain.Commands.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace iPlantino.Domain.Validations.Authentication
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
