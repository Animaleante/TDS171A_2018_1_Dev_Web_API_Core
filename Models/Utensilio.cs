using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class Utensilio
    {
        public long Id {get;set;}
        public string Nome {get;set;}

        public List<ReceitaUtensilio> ReceitasUtensilios {get;set;}
    }
}