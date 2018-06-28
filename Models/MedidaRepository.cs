using System.Collections.Generic;
using System.Linq;

namespace SoboruApi.Models
{
    public class MedidaRepository : Repository<Medida>, IMedidaRepository
    {
        public MedidaRepository(SoboruContext context) : base(context)
        {
            
        }
    }
}