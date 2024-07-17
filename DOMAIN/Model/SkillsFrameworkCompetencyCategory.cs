namespace DOMAIN.Model;

public class SkillsFrameworkCompetencyCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    // Fk SkillsFrameworkCompetencyType
    public int SfCompetencyTypeId { get; set; }
    public SkillsFrameworkCompetencyType SfCompetencyType { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
    public SectorDiscipline SectorDiscipline { get; set; }
}