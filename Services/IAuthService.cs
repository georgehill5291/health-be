using Healthcare.Models;
using Healthcare.Models.Auth;

namespace Healthcare.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterRequest req);
    Task<AuthResponse?> LoginAsync(LoginRequest req);
}

