using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionEvaluationSchedule;
public class AdmissionEvaluationScheduleDto
{
    [Required]
    [MinLength(20)]
    [MaxLength(2048)]
    public string EvaluationScheduleDescription { get; set; }
    [Required]
    public DateTime EvaluationScheduleStart { get; set; }
    [Required]
    public DateTime EvaluationScheduleEnd { get; set; }
    [Required]
    public bool IsOnlineMode { get; set; }
    [MaxLength(255)]
    public string? EvaluationOnlineLink { get; set; } // If IsOnlineMode
    [MaxLength(50)]
    public string? EvaluationOnlinePassword { get; set; } // If IsOnlineMode
    [MaxLength(255)]
    public string? EvaluationLocation { get; set; } // If face to face

    // Fk AdmissionSchedule 
    [Required]
    public int AdmissionScheduleId { get; set; }
}
