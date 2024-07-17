namespace DOMAIN.Model;

public class SkillsFrameworkPerformaceExpectationToJobRole
{
    public int Id { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJobRoleId { get; set; }
    public SkillsFrameworkJobRole SfJobRole { get; set; }

    // Fk SkillsFrameworkPerformanceExpectation
    public int SfPerformanceExpectationId { get; set; }
    public SkillsFrameworkPerformanceExpectation SfPerformanceExpectation { get; set; }
}