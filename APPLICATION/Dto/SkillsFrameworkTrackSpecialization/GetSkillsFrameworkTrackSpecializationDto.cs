using APPLICATION.Dto.SectorDiscipline;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
public class GetSkillsFrameworkTrackSpecializationDto
{
    public int Id { get; set; }
    public string Specialization { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
    public GetSectorDisciplineDto SectorDiscipline { get; set; }
}
