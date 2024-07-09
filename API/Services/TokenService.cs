using API.Entities;
using API.Interfaces;

namespace API.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string CreateToken(Appuser user)
        {
            throw new System.NotImplementedException();
        }
    }
}
