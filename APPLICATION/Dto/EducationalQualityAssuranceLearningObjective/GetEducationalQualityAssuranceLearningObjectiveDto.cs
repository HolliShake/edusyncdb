using APPLICATION.Dto.EducationalQualityAssuranceCourseObjective;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
public class GetEducationalQualityAssuranceLearningObjectiveDto
{
    public int Id { get; set; }
    public string EqaLearningObjective { get; set; }

    // Fk CourseObjective
    public int EqaCourseObjectiveId { get; set; }
    public GetEducationalQualityAssuranceCourseObjectiveDto EqaCourseObjective { get; set; }
}
