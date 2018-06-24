using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : Controller
    {
        private readonly SoboruContext _context;

        public ReceitaController(SoboruContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<ReceitaDTO>> GetAll() {
            //return _context.Receitas.ToList();
            /*return _context.Receitas
                .Include(re => re.ReceitasUtensilios)
                .ThenInclude(ru => ru.Utensilio)
                .ToList();*/
            return _context.Receitas.Include(r => r.ReceitasUtensilios).ThenInclude(ru => ru.Utensilio).Select(re => new ReceitaDTO {
                Id = re.Id,
                Nome = re.Nome,
                Utensilios = re.ReceitasUtensilios.Select(ru => new UtensilioDTO {
                    Id = ru.Utensilio.Id,
                    Nome = ru.Utensilio.Nome
                }).ToList()
            }).ToList();
        }

        [HttpGet("{id}", Name = "GetReceita")]
        public ActionResult<Receita> GetById(long id) {
            Receita receita = _context.Receitas.Find(id);
            if(receita == null) {
                return NotFound();
            }

            return receita;
        }

        [HttpPost]
        public IActionResult Create(Receita receita) {
            _context.Receitas.Add(receita);
            _context.SaveChanges();

            return CreatedAtRoute("GetReceita", new Receita{Id = receita.Id}, receita);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, Receita item) {
            Receita receita = _context.Receitas.Find(id);
            if(receita == null) {
                return NotFound();
            }

            receita.Nome = item.Nome;

            _context.Receitas.Update(receita);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            Receita receita = _context.Receitas.Find(id);
            if(receita == null) {
                return NotFound();
            }

            _context.Receitas.Remove(receita);
            _context.SaveChanges();

            return NoContent();
        }
    }
}