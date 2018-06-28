using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoboruApi.Models;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly IUsuarioRepository _repository;

        public RegisterController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario) {
            if(usuario != null && !String.IsNullOrWhiteSpace(usuario.Email)) {
                Usuario usuarioBase = await _repository.GetByEmail(usuario.Email);
                if(usuarioBase == null) {
                    await _repository.Add(usuario);
                    return Ok();
                } else {
                    return Conflict("Email já esta sendo utilizado.");
                }
            } else {
                return BadRequest();
            }
        }
    }
}