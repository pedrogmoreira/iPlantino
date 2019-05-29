using iPlantino.Authentication;
using iPlantino.Authentication.Models;
using iPlantino.Infra.CrossCutting.Jwt.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iPlantino.Infra.CrossCutting.Jwt
{
    public class JwtAutenticationService
    {
        private readonly TokenOptions _tokenOptions;
        private readonly AuthenticationService _authenticationService;

        public JwtAutenticationService(AuthenticationService autenticacaoService, IOptions<TokenOptions> JwtOptions)
        {
            _tokenOptions = JwtOptions.Value;
            _authenticationService = autenticacaoService;
        }

        public async Task<JwtToken> Authenticate(string login, string senha)
        {
            var user = await _authenticationService.Authenticate(new AuthenticateUser(login, senha));

            if (user == null)
            {
                return null;
            }

            var claims = GetClaims(user);

            var JwtSecurityToken = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claims,
                _tokenOptions.NotBefore,
                _tokenOptions.Expiration,
                _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);

            return new JwtToken
            {
                Token = encodedJwt,
                Expires = (int)_tokenOptions.ValidFor.TotalSeconds,
                User = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Username = user.Login
                }
            };
        }

        public IEnumerable<Claim> GetClaims(AuthenticatedUser user)
        {
            yield return new Claim(JwtRegisteredClaimNames.UniqueName, user.Login);
            yield return new Claim("name", user.Name);
            yield return new Claim(JwtRegisteredClaimNames.NameId, user.Login);
            if (user.Email != null)
                yield return new Claim(JwtRegisteredClaimNames.Email, user.Email);
            yield return new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString());
            yield return new Claim(JwtRegisteredClaimNames.Jti, _tokenOptions.JtiGenerator());
            yield return new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64);

            foreach (var permission in user.Permissions)
            {
                yield return new Claim(ClaimTypes.Role, permission);
            }
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}