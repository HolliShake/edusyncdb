namespace DOMAIN.Model;

public class SkillsFrameworkSkillsToCompetency
{
    public int Id { get; set; }

    // Fk SkillsFrameworksCompetency
    public int SfCompetencyId { get; set; }
    public SkillsFrameworkCompetency SfCompetency { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public SkillsFrameworkSkills SfSkills { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public SkillsFrameworkProficiencyLevel SfProficiencyLevel { get; set; }
}