using iPlantino.Domain.Commands.Registration;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using iPlantino.Infra.CrossCutting.Identity.Roles;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace iPlantino.Domain.CommandHandlers.Registration
{
    public class RegisterUserCommandHandler : Notifiable, IRequestHandler<RegisterUserCommand>    
    {
        private readonly IUserManager _userManager;

        public RegisterUserCommandHandler(IUserManager userManager, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser(request.Id, request.Name, request.Email.Address, request.Login.Value);

            var createUserIdentityResult = await _userManager.CreateUser(user, request.Password.Value);

            if (createUserIdentityResult.Succeeded)
            {
                var addToRolesIdentityResult = await _userManager.AddToRoles(user, DefaultRolesGroups.USER);

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
