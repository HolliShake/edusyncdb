using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRole;
public class GetSkillsFrameworkJobRoleDto
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string JobDescription { get; set; }

    // Fk Track
    public int SfTrackSpecializationId { get; set; }
    public GetSkillsFrameworkTrackSpecializationDto SfTrackSpecialization { get; set; }
}
