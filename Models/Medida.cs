namespace SoboruApi.Models
{
    public class Medida : IEntity
    {
        public long Id {get;set;}
        public string Nome {get;set;}
        public string Abreviacao {get;set;}
    }
}