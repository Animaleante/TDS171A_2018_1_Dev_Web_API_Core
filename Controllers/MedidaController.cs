using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;
using TDS171A_2018_1_Dev_Web_API_Core.Services;
using System.Threading.Tasks;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidaController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IMedidaRepository _repository;
        
        public MedidaController(IAuthService authService, IMedidaRepository repository) {
            _authService = authService;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Medida>> GetAll() {
            return _repository.List().ToList();
        }

        [HttpGet("{id}", Name = "GetMedida")]
        public async Task<ActionResult<Medida>> GetById(long id) {
            Medida medida = await _repository.GetById(id);
            if(medida == null) {
                return NotFound();
            }

            return medida;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromHeader] string Authorization, [FromBody] Medida medida) {
            if(!_authService.validateToken(Authorization)) {
                Response.Headers.Add("WWW-Authenticate", "");
                return Unauthorized(); 
            }

            await _repository.Add(medida);
            //_context.Medidas.Add(medida);
            //_context.SaveChanges();

            return CreatedAtRoute("GetMedida", new Medida{Id = medida.Id}, medida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Medida item) {
            Medida medida = await _repository.GetById(id);
            if(medida == null) {
                return NotFound();
            }

            medida.Nome = item.Nome;
            medida.Abreviacao = item.Abreviacao;

            await _repository.Update(medida);
            //_context.Medidas.Update(medida);
            //_context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            Medida medida = await _repository.GetById(id);
            if(medida == null) {
                return NotFound();
            }

            await _repository.Delete(medida);
            //_context.Medidas.Remove(medida);
            //_context.SaveChanges();

            return NoContent();
        }
    }
}