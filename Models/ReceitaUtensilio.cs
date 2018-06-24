namespace SoboruApi.Models
{
    public class ReceitaUtensilio
    {
        public long ReceitaId {get;set;}
        public virtual Receita Receita {get;set;}

        public long UtensilioId {get;set;}
        public virtual Utensilio Utensilio {get;set;}
    }
}