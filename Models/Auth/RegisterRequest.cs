namespace Healthcare.Models.Auth;

public record RegisterRequest(string Email, string Password, string? DisplayName = null, string? Role = null);

