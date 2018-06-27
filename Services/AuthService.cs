using SoboruApi.Models;

namespace TDS171A_2018_1_Dev_Web_API_Core.Services
{
    public class AuthService : IAuthService
    {
        public Usuario authUsuario(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public bool validateToken(string token)
        {
            return token.Equals("123");
            
        }
    }
}