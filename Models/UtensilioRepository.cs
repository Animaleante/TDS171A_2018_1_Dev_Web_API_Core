using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class UtensilioRepository : Repository<Utensilio>, IUtensilioRepository
    {

        public UtensilioRepository(SoboruContext context) : base(context)
        {
            
        }
    }
}