using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Authentication.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using iPlantino.Infra.CrossCutting.Identity.Entities;

namespace iPlantino.Authentication
{
    public class AuthenticationService : Notifiable
    {
        private readonly IRepository<ApplicationUser> _authenticationRepository;
        private readonly IAcessManager _userManager;

        public AuthenticationService(IUnitOfWork unitOfWork, IAcessManager userManager, IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(bus, notifications)
        {
            _authenticationRepository = unitOfWork.GetRepository<ApplicationUser>();
            _userManager = userManager;
        }

        public async Task<AuthenticatedUser> Authenticate(AuthenticateUser authenticateUser)
        {
            var validationResult = await new AuthenticateUserValidations().ValidateAsync(authenticateUser);

            await NotifyValidationErrors(validationResult);

            if (IsValid())
            {
                var user = await _authenticationRepository.GetFirstOrDefaultAsync(
               predicate: x => x.UserName == authenticateUser.Login,
                disableTracking: true,
                include: "UsersGroup.Group.PermissionsGroup.Permission");

                if (user == null)
                {
                    await Notify("Usuario", "Usuário ou Senha Inválidos");
                    return await Task.FromResult<AuthenticatedUser>(null);
                }

                if (_userManager.ValidateCredentials(user, authenticateUser.Password).Result.Succeeded)
                {
                    var roles = new List<string>();
                    foreach (var role in user.UserRoles.ToList())
                    {
                        roles.Add(role.Role.Name);
                    }
                    return new AuthenticatedUser(user.Id, user.Name, user.UserName,
                        user.Email, roles);
                }

                await Notify("Usuario", "Usuário ou Senha Inválidos");
            }

            return await Task.FromResult<AuthenticatedUser>(null);
        }
    }
}