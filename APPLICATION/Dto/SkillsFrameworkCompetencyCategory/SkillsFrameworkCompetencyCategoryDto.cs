using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
public class SkillsFrameworkCompetencyCategoryDto
{
    public string CategoryName { get; set; }

    // Fk SkillsFrameworkCompetencyType
    public int SfCompetencyTypeId { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
}
