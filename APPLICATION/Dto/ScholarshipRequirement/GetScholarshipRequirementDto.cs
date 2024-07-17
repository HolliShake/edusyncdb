using APPLICATION.Dto.Requirement;
using APPLICATION.Dto.ScholarshipList;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScholarshipRequirement;
public class GetScholarshipRequirementDto
{
    public int Id { get; set; }

    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }
    public GetScholarshipListDto ScholarshipList { get; set; }

    // Fk Requirement
    public int RequirementId { get; set; }
    public GetRequirementDto Requirement { get; set; }
}
