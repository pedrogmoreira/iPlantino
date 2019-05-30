using iPlantino.Domain.Core.Notifications;
using iPlantino.Services.Api.Infrastructure.Filters;
using iPlantino.Services.Api.Models;
using iPlantino.Infra.CrossCutting.Jwt;
using iPlantino.Infra.CrossCutting.Jwt.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iPlantino.Services.Api.Controllers
{
    /// <summary>
    /// Controler de Autenticação
    /// </summary>
    [Produces("application/json")]
    public class AuthenticationController : ApiController
    {
        private readonly JwtAutenticationService _authenticationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="authenticationService"></param>
        public AuthenticationController(INotificationHandler<DomainNotification> notifications, JwtAutenticationService authenticationService) : base(notifications)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Responsável por Autenticar o Usuário na API. Em uma açao bem sucedida é retornado os dados do usuário e o token de acesso.
        /// </summary>
        /// <param name="login">login e senha do usuário.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("api/authenticate")]
        [ProducesResponseType(typeof(JwtToken), 200)]
        [ProducesResponseType(typeof(IDictionary<string, IEnumerable<string>>), 400)]
        [ProducesResponseType(typeof(JsonErrorResponse), 500)]
        public async Task<IActionResult> Post([FromBody]LoginModel login)
        {
            return Response(await _authenticationService.Authenticate(login.Login, login.Password));
        }
    }
}