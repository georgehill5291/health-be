using System;

namespace Healthcare.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string? Role { get; set; }
    public string? DisplayName { get; set; }
    public Guid? PatientId { get; set; }
    public Guid? DoctorId { get; set; }
}

