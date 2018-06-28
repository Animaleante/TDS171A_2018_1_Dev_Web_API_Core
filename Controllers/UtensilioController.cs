using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Create(Utensilio utensilio) {
            await _repository.Add(utensilio);
            // _context.Utensilios.Add(utensilio);
            // _context.SaveChanges();

            return CreatedAtRoute("GetUtensilio", new Utensilio{Id = utensilio.Id}, utensilio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Utensilio item) {
            Utensilio utensilio = await _repository.GetById(id);
            if(utensilio == null) {
                return NotFound();
            }

            utensilio.Nome = item.Nome;

            await _repository.Update(utensilio);
            // _context.Utensilios.Update(utensilio);
            // _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            Utensilio utensilio = await _repository.GetById(id);
            if(utensilio == null) {
                return NotFound();
            }

            await _repository.Delete(utensilio);
            // _context.Utensilios.Remove(utensilio);
            // _context.SaveChanges();

            return NoContent();
        }
    }
}