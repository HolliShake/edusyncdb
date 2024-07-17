namespace DOMAIN.Model;

public class SkillsFrameworkJobRoleToCriticalWorkFunction
{
    public int Id { get; set; }

    // Fk SkillsFrameworkJobRole
    public int SfJoBRole { get; set; }
    public SkillsFrameworkJobRole SfJobRole { get; set; }

    // Fk SkillsFrameworkCriticalWorkFunction
    public int SfCriticalWorkFunctionId { get; set; }
    public SkillsFrameworkCriticalWorkFunction SfCriticalWorkFunction { get; set; }
}