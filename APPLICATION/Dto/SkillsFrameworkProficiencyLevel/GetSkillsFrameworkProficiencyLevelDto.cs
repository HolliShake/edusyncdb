using APPLICATION.Dto.SkillsFrameworkGroupLevel;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
public class GetSkillsFrameworkProficiencyLevelDto
{
    public int Id { get; set; }
    public string ProficiencyLevel { get; set; }

    // Fk SkillsFrameworkGroupLevel
    public int SfGroupLevelId { get; set; }
    public GetSkillsFrameworkGroupLevelDto SfGroupLevel { get; set; }
}
