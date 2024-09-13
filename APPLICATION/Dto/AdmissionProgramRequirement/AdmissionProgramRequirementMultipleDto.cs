using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLICATION.Dto.AdmissionProgramRequirement;

public class AdmissionProgramRequirementMultipleDto
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
    public int[] RequirementIds { get; set; }
}