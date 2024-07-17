using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRole;
public class SkillsFrameworkJobRoleDto
{
    public string Role { get; set; }
    public string JobDescription { get; set; }

    // Fk Track
    public int SfTrackSpecializationId { get; set; }
}
