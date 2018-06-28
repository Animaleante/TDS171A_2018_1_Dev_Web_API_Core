using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidaController : Controller
    {
        private readonly IMedidaRepository _repository;
        
        public MedidaController(IMedidaRepository repository) {
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

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Create(Medida medida) {
            await _repository.Add(medida);

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

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            Medida medida = await _repository.GetById(id);
            if(medida == null) {
                return NotFound();
            }

            await _repository.Delete(medida);

            return NoContent();
        }
    }
}