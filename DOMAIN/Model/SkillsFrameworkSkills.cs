
namespace DOMAIN.Model;

public class SkillsFrameworkSkills
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Fk SkillsFrameworkCompetencyCatregory
    public int SfCompetencyCategoryId { get; set; }
    public SkillsFrameworkCompetencyCategory SfCompetencyCategory { get; set; }
}