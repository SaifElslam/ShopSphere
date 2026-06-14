using Microsoft.EntityFrameworkCore;
using ShopSphere.Data;
using ShopSphere.DTOs;
using ShopSphere.Models;
using ShopSphere.Services.Auth;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthService(
        ApplicationDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    public async Task<string> RegisterAsync(RegisterDto dto)
    {
        var exists = await _context.users
            .AnyAsync(x => x.Email == dto.Email);

        if (exists)
            return "Email already exists";

        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _context.users.Add(user);

        await _context.SaveChangesAsync();

        return "User registered successfully";
    }

    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var user = await _context.users
            .FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
            return null;

        bool valid =
            BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash);

        if (!valid)
            return null;

        return _jwtService.GenerateToken(user);
    }
}