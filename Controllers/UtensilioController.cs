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
    public class UtensilioController : Controller
    {
        private readonly IUtensilioRepository _repository;

        public UtensilioController(IUtensilioRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Utensilio>> GetAll() {
            return _repository.List().ToList();
        }

        [HttpGet("{id}", Name = "GetUtensilio")]
        public async Task<ActionResult<Utensilio>> GetById(long id) {
            Utensilio utensilio = await _repository.GetById(id);
            if(utensilio == null) {
                return NotFound();
            }

            return utensilio;
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> Create(Utensilio utensilio) {
            await _repository.Add(utensilio);

            return CreatedAtRoute("GetUtensilio", new Utensilio{Id = utensilio.Id}, utensilio);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Utensilio item) {
            Utensilio utensilio = await _repository.GetById(id);
            if(utensilio == null) {
                return NotFound();
            }

            utensilio.Nome = item.Nome;

            await _repository.Update(utensilio);

            return NoContent();
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            Utensilio utensilio = await _repository.GetById(id);
            if(utensilio == null) {
                return NotFound();
            }

            await _repository.Delete(utensilio);

            return NoContent();
        }
    }
}