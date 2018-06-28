using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SoboruApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SoboruApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : Controller
    {
        private IReceitaRepository _repository;

        public ReceitaController(IReceitaRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<ReceitaDTO>> GetAll() {
            return _repository.GetAllFull().Select(re => new ReceitaDTO {
                Id = re.Id,
                Nome = re.Nome,
                Utensilios = re.ReceitasUtensilios.Select(ru => new UtensilioDTO {
                    Id = ru.Utensilio.Id,
                    Nome = ru.Utensilio.Nome
                }).ToList()
            }).ToList();
        }

        [HttpGet("{id}", Name = "GetReceita")]
        public ActionResult<ReceitaDTO> GetById(long id) {
            ReceitaDTO receita = _repository.GetFullById(id).Select(re => new ReceitaDTO {
                Id = re.Id,
                Nome = re.Nome,
                Utensilios = re.ReceitasUtensilios.Select(ru => new UtensilioDTO {
                    Id = ru.Utensilio.Id,
                    Nome = ru.Utensilio.Nome
                }).ToList()
            }).First();

            if(receita == null) {
                return NotFound();
            }

            /*ReceitaUtensilio receitaUtensilio = new ReceitaUtensilio();
            receitaUtensilio.ReceitaId = receita.Id;
            receitaUtensilio.UtensilioId = 2;

            receita.ReceitasUtensilios.Add(receitaUtensilio);
            _context.SaveChanges();*/

            return receita;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Receita receita) {
            await _repository.Add(receita);

            return CreatedAtRoute("GetReceita", new Receita{Id = receita.Id}, receita);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ReceitaDTO item) {
            Receita receita = await _repository.GetById(id);
            if(receita == null) {
                return NotFound();
            }

            receita.Nome = item.Nome;

            await _repository.Update(receita);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            Receita receita = await _repository.GetById(id);
            if(receita == null) {
                return NotFound();
            }

            await _repository.Delete(receita);

            return NoContent();
        }
    }
}