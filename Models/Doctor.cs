using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models;

public class Doctor
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Specialty { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
