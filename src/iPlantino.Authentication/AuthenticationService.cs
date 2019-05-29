using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Domain.Models.Authentication;
using iPlantino.Authentication.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace iPlantino.Authentication
{
    public class AuthenticationService : Notifiable
    {
        private readonly IRepository<User> _authenticationRepository;

        public AuthenticationService(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _authenticationRepository = unitOfWork.GetRepository<User>();
        }

        public async Task<AuthenticatedUser> Authenticate(AuthenticateUser authenticateUser)
        {
            var validationResult = await new AuthenticateUserValidations().ValidateAsync(authenticateUser);

            await NotifyValidationErrors(validationResult);

            if (IsValid())
            {
                var user = await _authenticationRepository.GetFirstOrDefaultAsync(
               predicate: x => x.Login == authenticateUser.Login,
                disableTracking: true,
                include: "UsersGroup.Group.PermissionsGroup.Permission");

                if (user == null || user.Deleted != null)
                {
                    await Notify("Usuario", "Usuário ou Senha Inválidos");
                    return await Task.FromResult<AuthenticatedUser>(null);
                }

                if (user.Authenticate(authenticateUser.Login, authenticateUser.Password))
                {
                    return new AuthenticatedUser(user.Id, user.Name, user.Login,
                        user.Email, user.Permissions);
                }

                await Notify("Usuario", "Usuário ou Senha Inválidos");
            }

            return await Task.FromResult<AuthenticatedUser>(null);
        }
    }
}