using System.Collections.Generic;

namespace SoboruApi.Models
{
    public class ReceitaDTO
    {
        public long Id {get;set;}
        public string Nome {get;set;}

        public IList<UtensilioDTO> Utensilios {get;set;}
    }
}