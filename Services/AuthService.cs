using Healthcare.Data;
using Healthcare.Models;
using Healthcare.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly IPasswordHasher<User> _hasher;
    private readonly ITokenService _tokenService;

    public AuthService(AppDbContext db, IPasswordHasher<User> hasher, ITokenService tokenService)
    {
        _db = db;
        _hasher = hasher;
        _tokenService = tokenService;
    }

    public async Task<User> RegisterAsync(RegisterRequest req)
    {
        if (await _db.Users.AnyAsync(u => u.Email == req.Email))
            throw new InvalidOperationException("email_taken");

        var user = new User
        {
            Email = req.Email,
            DisplayName = req.DisplayName,
            Role = req.Role
        };

        user.PasswordHash = _hasher.HashPassword(user, req.Password);
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest req)
    {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == req.Email);
        if (user == null) return null;

        var res = _hasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);
        if (res == PasswordVerificationResult.Failed) return null;

        var token = _tokenService.CreateToken(user);
        return new AuthResponse(token, DateTime.UtcNow.AddHours(8));
    }
}

