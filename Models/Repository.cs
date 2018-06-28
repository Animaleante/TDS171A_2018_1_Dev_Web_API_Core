using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoboruApi.Models
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly SoboruContext _context;

        public Repository(SoboruContext context)
        {
            _context = context;
        }

        public async Task Add(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task Update(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
        }
    }
}