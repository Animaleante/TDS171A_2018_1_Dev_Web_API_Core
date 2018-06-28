using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoboruApi.Models
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> List();
        Task<T> GetById(long id);
        Task Add(T model);
        Task Update(T model);
        Task Delete(T model);
    }
}