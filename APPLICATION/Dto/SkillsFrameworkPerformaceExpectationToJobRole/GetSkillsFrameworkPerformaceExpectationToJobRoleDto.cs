using APPLICATION.Dto.SkillsFrameworkJobRole;
using APPLICATION.Dto.SkillsFrameworkPerformanceExpectation;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkPerformaceExpectationToJobRole;
public class GetSkillsFrameworkPerformaceExpectationToJobRoleDto
{
    public int Id { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }
    public GetSkillsFrameworkJobRoleDto SfJobRole { get; set; }

    // Fk SkillsFrameworkPerformanceExpectation
    public int SfPerformanceExpectationId { get; set; }
    public GetSkillsFrameworkPerformanceExpectationDto SfPerformanceExpectation { get; set; }
}
