using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.AdmissionProgramRequirement;
public class AdmissionProgramRequirementDto
{
    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal PassingScore { get; set; }
    [Required]
    public bool IsEnabled { get; set; }

    // Fk AdmissionSchedule
    [Required]
    public int AdmissionScheduleId { get; set; }

    // Fk Requirement
    [Required]
    public int RequirementId { get; set; }
}
