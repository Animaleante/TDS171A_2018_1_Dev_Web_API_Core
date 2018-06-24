using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class Receita
    {
        public long Id {get;set;}
        public string Nome {get;set;}

        public List<ReceitaUtensilio> ReceitasUtensilios {get;set;}
    }
}