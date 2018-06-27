using System.Collections.Generic;

namespace SoboruApi.Models
{
    public interface IRepository<T>
    {
        T Add(T model);
        bool Update(T model);
        List<T> List();
        bool Delete(long id);
    }
}