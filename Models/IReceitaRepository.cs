using System.Linq;
using System.Threading.Tasks;

namespace SoboruApi.Models
{
    public interface IReceitaRepository : IRepository<Receita>
    {
        IQueryable<Receita> GetAllFull();
        IQueryable<Receita> GetFullById(long id);
    }
}