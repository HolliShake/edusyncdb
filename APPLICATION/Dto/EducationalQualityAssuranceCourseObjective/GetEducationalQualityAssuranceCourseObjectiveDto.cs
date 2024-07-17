using APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
public class GetEducationalQualityAssuranceCourseObjectiveDto
{
    public int Id { get; set; }
    public string EqaCourseObjective { get; set; }

    // Fk EQAProgramObjective
    public int EqaProgramObjectiveId { get; set; }
    public GetEducationalQualityAssuranceProgramObjectiveDto EqaProgramObjective { get; set; }
}
