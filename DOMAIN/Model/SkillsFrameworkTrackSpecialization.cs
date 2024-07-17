
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class SkillsFrameworkTrackSpecialization
{
    public int Id { get; set; }
    public string Specialization { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
    public SectorDiscipline SectorDiscipline { get; set; }
}