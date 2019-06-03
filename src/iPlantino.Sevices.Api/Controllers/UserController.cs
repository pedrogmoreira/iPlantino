using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Egl.Sit.Api.V1.Usuarios.Models;
using iPlantino.Domain.AggregatesModel.UserAggregate;
using iPlantino.Domain.Commands.Authentication;
using iPlantino.Domain.Core.Bus;
using iPlantino.Domain.Core.Notifications;
using iPlantino.Services.Api.Controllers;
using iPlantino.Services.Api.Infrastructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iPlantino.Sevices.Api.Controllers
{
    [Route("api/user")]
    [Produces("application/json")]
    public class UserController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="authenticationService"></param>
        public UserController(INotificationHandler<DomainNotification> notifications) : base(notifications) { }

        /// <summary>
        /// Detalha um usuário.
        /// Roles: [usuarios-detalhar,usuarios-adicionar]
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("{idUsuario}")]
        [ProducesResponseType(typeof(DetalhesUsuarioModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Get([FromServices]IUserRepository userRepository, [FromRoute] Guid idUsuario)
        {
            Expression<Func<User, bool>> predicate = p => p.Id == idUsuario;

            Expression<Func<User, DetalhesUsuarioModel>> selector = user => new DetalhesUsuarioModel
            {
                Id = user.Id,
                Nome = user.Name,
                Login = user.UserName,
                Email = user.Email,
                ContadorErroSenha = user.AccessFailedCount,
                DataFimDoBloqueio = user.LockoutEnd,
                Telefone = user.PhoneNumber,
                Grupos = user.UserRole.Select(x => x.Role.Name)
            };

            var result = await userRepository.Get(selector, predicate, includes: "UserRole.Role");

            return Response(result);
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// Roles: [usuarios-adicionar]
        /// </summary>  
        /// <param name="bus"></param>
        /// <param name="novoUsuarioModel"></param>
        /// <returns>Id do Usuário Criado <see cref="UsuarioAdicionadoModel"/></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioAdicionadoModel), 201)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Post([FromServices]IMediatorHandler bus, [FromBody] AdicionarUsuarioModel novoUsuarioModel)
        {
            var comando = new RegisterUserCommand(novoUsuarioModel.Nome, novoUsuarioModel.Login,
                                                         novoUsuarioModel.Senha, novoUsuarioModel.ConfirmaSenha, novoUsuarioModel.Email);
            await bus.SendCommand(comando);
            return ResponseCreated($"api/usuarios/{comando.Id}", new UsuarioAdicionadoModel { Id = comando.Id, Login = comando.Login.Value });
        }
    }
}