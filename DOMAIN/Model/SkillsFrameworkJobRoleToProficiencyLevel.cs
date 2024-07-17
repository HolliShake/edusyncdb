namespace DOMAIN.Model;

public class SkillsFrameworkJobRoleToProficiencyLevel
{
    public int Id { get; set; }

    // Fk SkillsFrameworkJobRoleToCriticalWorkFunction
    public int SfJobRoleToCriticalWorkFunctionId { get; set; }
    public SkillsFrameworkJobRoleToCriticalWorkFunction SfJobRoleToCriticalWorkFunction { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public SkillsFrameworkSkills SkillsFrameworkSkills { get; set; }

    // FK SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public SkillsFrameworkProficiencyLevel SfProficiencyLevel { get; set; }
}