namespace SoboruApi.Models
{
    public class ReceitaUtensilio
    {
        public long ReceitaId {get;set;}
        public Receita Receita {get;set;}

        public long UtensilioId {get;set;}
        public Utensilio Utensilio {get;set;}
    }
}