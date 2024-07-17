using APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkSkills;
public class GetSkillsFrameworkSkillsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Fk SkillsFrameworkCompetencyCatregory
    public int SfCompetencyCategoryId { get; set; }
    public GetSkillsFrameworkCompetencyCategoryDto SfCompetencyCategory { get; set; }
}
