namespace Healthcare.Models.Auth;

public record AuthResponse(string Token, DateTime ExpiresAt);

