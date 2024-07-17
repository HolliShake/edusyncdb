using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkJobRoleToProficiencyLevel;
public class SkillsFrameworkJobRoleToProficiencyLevelDto
{
    // Fk SkillsFrameworkJobRoleToCriticalWorkFunction
    public int SfJobRoleToCriticalWorkFunctionId { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }

    // FK SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
}
