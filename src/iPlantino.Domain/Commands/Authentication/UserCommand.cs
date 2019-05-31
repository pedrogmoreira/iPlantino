using iPlantino.Domain.Core.Commands;
using iPlantino.Domain.ValueObjects;

namespace iPlantino.Domain.Commands.Authentication
{
    public abstract class UserCommand : Command
    {
        public string Name { get; protected set; }
        public Login Login { get; protected set; }
        public Password Password { get; protected set; }
        public Password PasswordConfirmation { get; protected set; }
        public string Telephone { get; protected set; }
        public Email Email { get; protected set; }
    }
}
