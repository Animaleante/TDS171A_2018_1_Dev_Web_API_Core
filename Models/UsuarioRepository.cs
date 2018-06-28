using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoboruApi.Models
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SoboruContext context) : base(context)
        {
            
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}