using ShopSphere.Models;

namespace ShopSphere.Services.Auth
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
