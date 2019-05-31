using iPlantino.Domain.Commands.Authentication;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Domain.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iPlantino.Domain.CommandHandlers.Authentication
{
    public class RegisterUserCommandHandler : Notifiable, IRequestHandler<RegisterUserCommand>    
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(UserManager userManager, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Login.ToString(), request.Password.ToString(), request.Telephone, request.Email.ToString());

            var createUserIdentityResult = await _userManager.CreateUser(user, request.Password.Value);

            if (createUserIdentityResult.Succeeded)
            {
                var addToRolesIdentityResult = await _userManager.AddToRoles(user, request.Roles);

                foreach (var erro in addToRolesIdentityResult?.Errors)
                {
                    await Notify(erro.Code, erro.Description);
                }
            }

            foreach (var erro in createUserIdentityResult?.Errors)
            {
                await Notify(erro.Code, erro.Description);
            }

            return Unit.Value;
        }

    }
}
