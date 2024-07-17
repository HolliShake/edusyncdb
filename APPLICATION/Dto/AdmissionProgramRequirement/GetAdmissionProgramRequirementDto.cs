using APPLICATION.Dto.AdmissionSchedule;
using APPLICATION.Dto.Requirement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.AdmissionProgramRequirement;
public class GetAdmissionProgramRequirementDto
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal PassingScore { get; set; }
    public bool IsEnabled { get; set; }

    // Fk AdmissionSchedule
    public int AdmissionScheduleId { get; set; }
    public GetAdmissionScheduleDto AdmissionSchedule { get; set; }

    // Fk Requirement
    public int RequirementId { get; set; }
    public GetRequirementDto Requirement { get; set; }
}
