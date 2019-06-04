using iPlantino.Domain.Core.Commands;
using iPlantino.Domain.ValueObjects;
using System;

namespace iPlantino.Domain.Commands
{
    public abstract class UserCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public Login Login { get; protected set; }
        public Password Password { get; protected set; }
        public Password PasswordConfirmation { get; protected set; }
        public string Telephone { get; protected set; }
        public Email Email { get; protected set; }
    }
}
