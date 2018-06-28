using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoboruApi.Auth;
using SoboruApi.Models;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public LoginController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Post([FromBody] Usuario usuario, [FromServices] SigningConfigurations signingConfigurations, [FromServices] TokenConfigurations tokenConfigurations) {
            bool validCredentials = false;
            if(usuario != null && !String.IsNullOrWhiteSpace(usuario.Email)) {
                Usuario usuarioBase = await _repository.GetByEmail(usuario.Email);
                validCredentials = (usuarioBase != null &&
                    usuario.Email == usuarioBase.Email &&
                    usuario.Senha == usuarioBase.Senha);
            }

            if(validCredentials) {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, "Login"),
                    new [] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)
                    }
                );

                DateTime createdAt = DateTime.Now;
                DateTime expiresAt = createdAt + TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createdAt,
                    Expires = expiresAt
                });

                var token = handler.WriteToken(securityToken);

                return new {
                    authenticated = true,
                    created = createdAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expiresAt.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            } else {
                return new {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}