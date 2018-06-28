using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoboruApi.Models
{
    public class ReceitaRepository : Repository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(SoboruContext context) : base(context)
        {
            
        }

        public IQueryable<Receita> GetAllFull()
        {
            return List().Include(r => r.ReceitasUtensilios).ThenInclude(ru => ru.Utensilio);
        }

        public IQueryable<Receita> GetFullById(long id)
        {
            return List().Where(r => r.Id == id).Include(r => r.ReceitasUtensilios).ThenInclude(ru => ru.Utensilio);
        }
    }
}