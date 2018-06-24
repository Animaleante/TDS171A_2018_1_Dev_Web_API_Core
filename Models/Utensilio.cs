using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class Utensilio
    {
        public long Id {get;set;}
        public string Nome {get;set;}

        public virtual IList<ReceitaUtensilio> ReceitasUtensilios {get;set;}
    }
}