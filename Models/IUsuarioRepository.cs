using System.Threading.Tasks;

namespace SoboruApi.Models
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmail(string email);
    }
}