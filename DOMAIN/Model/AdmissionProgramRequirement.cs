
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace DOMAIN.Model;

public class AdmissionProgramRequirement
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal PassingScore { get; set; }
    public bool IsEnabled { get; set; }

    // Fk AdmissionSchedule
    public int AdmissionScheduleId { get; set; }
    public AdmissionSchedule AdmissionSchedule { get; set; }

    // Fk Requirement
    public int RequirementId { get; set; }
    public Requirement Requirement { get; set; }
}