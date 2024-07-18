using System.Security.Claims;

namespace APPLICATION.Jwt;

public abstract class JwtGenerator
{
    public static JwtAuthResult GenerateToken(IJwtAuthManager ijwAuthManager, string id, string userEmail, string role, string accessListString)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.Role, role),
            new Claim("AccessList", accessListString)
        };

        return ijwAuthManager.GenerateTokens(userEmail, claims, DateTime.Now);
    }
}