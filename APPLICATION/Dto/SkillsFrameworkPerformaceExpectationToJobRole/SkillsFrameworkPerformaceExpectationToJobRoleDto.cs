using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
public class SkillsFrameworkPerformaceExpectationToJobRoleDto
{
    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }

    // Fk SkillsFrameworkPerformanceExpectation
    public int SfPerformanceExpectationId { get; set; }
}
