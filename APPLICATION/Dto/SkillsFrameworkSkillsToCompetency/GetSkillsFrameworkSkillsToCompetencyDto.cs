using APPLICATION.Dto.SkillsFrameworkCompetency;
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.Dto.SkillsFrameworkSkills;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkSkillsToCompetency;
public class GetSkillsFrameworkSkillsToCompetencyDto
{
    public int Id { get; set; }

    // Fk SkillsFrameworksCompetency
    public int SfCompetencyId { get; set; }
    public GetSkillsFrameworkCompetencyDto SfCompetency { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public GetSkillsFrameworkSkillsDto SfSkills { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public GetSkillsFrameworkProficiencyLevelDto SfProficiencyLevel { get; set; }
}
