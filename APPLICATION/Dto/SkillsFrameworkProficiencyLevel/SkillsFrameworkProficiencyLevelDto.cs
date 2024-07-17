using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
public class SkillsFrameworkProficiencyLevelDto
{
    public string ProficiencyLevel { get; set; }

    // Fk SkillsFrameworkGroupLevel
    public int SfGroupLevelId { get; set; }
}
