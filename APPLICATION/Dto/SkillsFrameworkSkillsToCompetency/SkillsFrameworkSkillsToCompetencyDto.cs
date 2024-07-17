using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
public class SkillsFrameworkSkillsToCompetencyDto
{
    // Fk SkillsFrameworksCompetency
    public int SfCompetencyId { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
}
