using SoboruApi.Models;

namespace TDS171A_2018_1_Dev_Web_API_Core.Services
{
    public interface IAuthService
    {
        Usuario authUsuario(Usuario usuario);
        bool validateToken(string token);
    }
}