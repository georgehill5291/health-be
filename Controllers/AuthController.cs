using Healthcare.Services;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Healthcare.Models.Auth.RegisterRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("email and password required");

        try
        {
            var user = await _auth.RegisterAsync(req);
            return Ok(new { message = "User registered successfully", id = user.Id, email = user.Email });
        }
        catch (InvalidOperationException ex) when (ex.Message == "email_taken")
        {
            return Conflict("email_taken");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Healthcare.Models.Auth.LoginRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Email) || string.IsNullOrWhiteSpace(req.Password))
            return BadRequest("email and password required");

        var auth = await _auth.LoginAsync(req);
        if (auth == null) return Unauthorized("invalid_credentials");
        return Ok(auth);
    }
}
