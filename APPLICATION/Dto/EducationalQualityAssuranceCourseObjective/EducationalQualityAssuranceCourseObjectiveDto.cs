using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
public class EducationalQualityAssuranceCourseObjectiveDto
{
    public string EqaCourseObjective { get; set; }

    // Fk EQAProgramObjective
    public int EqaProgramObjectiveId { get; set; }
}
