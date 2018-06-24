using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtensilioController : Controller
    {
        private readonly SoboruContext _context;

        public UtensilioController(SoboruContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Utensilio>> GetAll() {
            return _context.Utensilios.ToList();
        }

        [HttpGet("{id}", Name = "GetUtensilio")]
        public ActionResult<Utensilio> GetById(long id) {
            Utensilio utensilio = _context.Utensilios.Find(id);
            if(utensilio == null) {
                return NotFound();
            }

            return utensilio;
        }

        [HttpPost]
        public IActionResult Create(Utensilio utensilio) {
            _context.Utensilios.Add(utensilio);
            _context.SaveChanges();

            return CreatedAtRoute("GetUtensilio", new Utensilio{Id = utensilio.Id}, utensilio);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Utensilio item) {
            Utensilio utensilio = _context.Utensilios.Find(id);
            if(utensilio == null) {
                return NotFound();
            }

            utensilio.Nome = item.Nome;

            _context.Utensilios.Update(utensilio);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            Utensilio utensilio = _context.Utensilios.Find(id);
            if(utensilio == null) {
                return NotFound();
            }

            _context.Utensilios.Remove(utensilio);
            _context.SaveChanges();

            return NoContent();
        }
    }
}