using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipRequirement;
public class ScholarshipRequirementDto
{
    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }

    // Fk Requirement
    public int RequirementId { get; set; }
}
