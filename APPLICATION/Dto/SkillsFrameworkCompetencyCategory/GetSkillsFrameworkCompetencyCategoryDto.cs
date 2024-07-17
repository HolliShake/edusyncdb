using APPLICATION.Dto.SectorDiscipline;
using APPLICATION.Dto.SkillsFrameworkCompetencyType;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkCompetencyCategory;
public class GetSkillsFrameworkCompetencyCategoryDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    // Fk SkillsFrameworkCompetencyType
    public int SfCompetencyTypeId { get; set; }
    public GetSkillsFrameworkCompetencyTypeDto SfCompetencyType { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
    public GetSectorDisciplineDto SectorDiscipline { get; set; }
}
