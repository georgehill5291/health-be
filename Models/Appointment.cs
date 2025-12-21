using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    // Always store UTC in DB
    public DateTime StartUtc { get; set; }

    public int DurationMinutes { get; set; } = 30;

    [MaxLength(1000)]
    public string? Notes { get; set; }
}
