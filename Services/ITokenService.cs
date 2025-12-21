using Healthcare.Models;

namespace Healthcare.Services;

public interface ITokenService
{
    string CreateToken(User user, TimeSpan? expires = null);
}
