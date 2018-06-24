using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedidaController : Controller
    {
        private readonly SoboruContext _context;

        public MedidaController(SoboruContext context) {
            _context = context;

            if(_context.Medidas.Count() == 0) {
                _context.Medidas.Add(new Medida{Nome = "Gramas", Abreviacao = "gr"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Medida>> GetAll() {
            return _context.Medidas.ToList();
        }

        [HttpGet("{id}", Name = "GetMedida")]
        public ActionResult<Medida> GetById(long id) {
            Medida medida = _context.Medidas.Find(id);
            if(medida == null) {
                return NotFound();
            }

            return medida;
        }

        [HttpPost]
        public IActionResult Create(Medida medida) {
            _context.Medidas.Add(medida);
            _context.SaveChanges();

            return CreatedAtRoute("GetMedida", new Medida{Id = medida.Id}, medida);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Medida item) {
            Medida medida = _context.Medidas.Find(id);
            if(medida == null) {
                return NotFound();
            }

            medida.Nome = item.Nome;
            medida.Abreviacao = item.Abreviacao;

            _context.Medidas.Update(medida);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            var medida = _context.Medidas.Find(id);
            if(medida == null) {
                return NotFound();
            }

            _context.Medidas.Remove(medida);
            _context.SaveChanges();

            return NoContent();
        }
    }
}