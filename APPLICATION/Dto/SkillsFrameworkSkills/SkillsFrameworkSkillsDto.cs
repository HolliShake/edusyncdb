using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkSkills;
public class SkillsFrameworkSkillsDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    // Fk SkillsFrameworkCompetencyCatregory
    public int SfCompetencyCategoryId { get; set; }
}
