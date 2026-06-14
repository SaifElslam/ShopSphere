using ShopSphere.DTOs;
using ShopSphere.Models;
public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }

