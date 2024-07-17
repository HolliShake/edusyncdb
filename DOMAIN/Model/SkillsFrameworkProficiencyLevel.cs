namespace DOMAIN.Model;

public class SkillsFrameworkProficiencyLevel
{
    public int Id { get; set; }
    public string ProficiencyLevel { get; set; }

    // Fk SkillsFrameworkGroupLevel
    public int SfGroupLevelId { get; set; }
    public SkillsFrameworkGroupLevel SfGroupLevel { get; set; }
}