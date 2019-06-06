using System.Collections.Generic;
using System.Threading.Tasks;
using iPlantino.Services.Api.Models.UserModels;
using iPlantino.Domain.Commands.Registration;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Services.Api.Controllers;
using iPlantino.Services.Api.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iPlantino.Domain.Core.UnitOfWork;
using iPlantino.Infra.CrossCutting.Identity.Entities;
using System.Linq;

namespace iPlantino.Sevices.Api.Controllers
{
    /// <summary>
    /// Controller for user actions
    /// </summary>
    [Produces("application/json")]
    public class UserController : ApiController
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="notifications"></param>
        public UserController(IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _userRepository = unitOfWork.GetRepository<ApplicationUser>();
        }

        /// <summary>
        /// Details a user
        /// Roles: [user-details]
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet("api/user/{username}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Get([FromRoute] string username)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(
               predicate: x => x.UserName == username,
                disableTracking: true,
                include: new string[] { "UserRoles.Role.RoleClaims.Role", "UserArduinos.Arduino" });

            var result = new UserDetailsModel
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.UserName,
                Email = user.Email,
                AccessFailedCount = user.AccessFailedCount,
                Groups = user.UserRoles.Select(x => x.Role.RoleClaims.Select(c => c.ClaimValue).ToString()),
                Devices = user.UserArduinos.Select(x => x.Arduino.Name + " " + x.Arduino.MacAdrress)
            };

            return Response(result);
        }

        /// <summary>
        /// Registers a new user
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="registerUserModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/user/register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisteredModel), 201)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Post([FromServices]IMediatorHandler bus, [FromBody] RegisterUserModel registerUserModel)
        {
            var command = new RegisterUserCommand(registerUserModel.Name, registerUserModel.Login,
                                                         registerUserModel.Password, registerUserModel.PasswordConfirmation, registerUserModel.Email);
            await bus.SendCommand(command);
            return ResponseCreated($"api/user/{command.Id}", new UserRegisteredModel { Id = command.Id, Login = command.Login.Value });
        }
    }
}