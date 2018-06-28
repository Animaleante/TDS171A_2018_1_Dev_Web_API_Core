namespace SoboruApi.Models
{
    public class Usuario : IEntity
    {
        public long Id {get;set;}
        public string Email {get;set;}
        public string Nome {get;set;}

        public string Senha {get;set;}
    }
}