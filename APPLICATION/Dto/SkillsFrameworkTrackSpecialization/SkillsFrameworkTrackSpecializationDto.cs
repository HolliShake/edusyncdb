using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
public class SkillsFrameworkTrackSpecializationDto
{
    public string Specialization { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
}
