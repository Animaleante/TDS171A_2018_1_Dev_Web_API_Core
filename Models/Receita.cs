using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class Receita
    {
        public long Id {get;set;}
        public string Nome {get;set;}

        public virtual IList<ReceitaUtensilio> ReceitasUtensilios {get;set;}
    }
}