using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyApi.Infrastructure.Config.Identity
{
    public class JwtTokenKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
