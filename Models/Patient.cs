using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models;

public class Patient
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress, MaxLength(200)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
