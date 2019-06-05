using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPlantino.Services.Api.V1.Usuarios.Models;
using iPlantino.Domain.AggregatesModel.UserAggregate;
using iPlantino.Domain.Commands.Registration;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Services.Api.Controllers;
using iPlantino.Services.Api.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using iPlantino.Infra.CrossCutting.Identity.Interfaces;
using iPlantino.Services.Api.Models.UserModels;
using iPlantino.Domain.Commands.Device;

namespace iPlantino.Sevices.Api.Controllers
{
    /// <summary>
    /// Controler de Autenticação
    /// </summary>
    [Produces("application/json")]
    public class UserController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        public UserController(INotificationHandler<DomainNotification> notifications) : base(notifications) { }

        /// <summary>
        /// Detalha um usuário.
        /// Roles: [usuarios-detalhar,usuarios-adicionar]
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("api/user/{idUsuario}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserDetailsModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Get([FromServices]IUserRepository userRepository, [FromServices] IUserManager userManager, [FromRoute] Guid idUsuario)
        {
            var user = await userManager.GetById(idUsuario);

            var result = new UserDetailsModel
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.UserName,
                Email = user.Email,
                AccessFailedCount = user.AccessFailedCount,
                //Groups = user.UserRoles.Select(x => x.Role.Name)
            };

            return Response(result);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// Roles: [usuarios-adicionar]
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="registerUserModel"></param>
        /// <returns>Id do Usuário Criado <see cref="UserRegisteredModel"/></returns>
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

        /// <summary>
        /// Adiciona um novo usuário.
        /// Roles: [usuarios-adicionar]
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="addDeviceModel"></param>
        /// <returns>Id do Usuário Criado <see cref="UserRegisteredModel"/></returns>
        [HttpPost]
        [Route("api/user/add/device")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserRegisteredModel), 201)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Post([FromServices]IMediatorHandler bus, [FromBody] AddDeviceModel addDeviceModel)
        {
            var command = new AddDeviceCommand(addDeviceModel.Name, addDeviceModel.Observation,
                                                         addDeviceModel.MacAddress, addDeviceModel.UserId);
            await bus.SendCommand(command);
            return ResponseCreated($"api/user/{command.Id}", new DeviceAdded { Id = command.Id.ToString(), Name = command.Name, MacAddress = command.MacAddress, Observation = command.Observation });
        }
    }
}