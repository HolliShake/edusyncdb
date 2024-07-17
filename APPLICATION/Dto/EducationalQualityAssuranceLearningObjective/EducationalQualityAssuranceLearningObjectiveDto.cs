using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
public class EducationalQualityAssuranceLearningObjectiveDto
{
    public string EqaLearningObjective { get; set; }

    // Fk CourseObjective
    public int EqaCourseObjectiveId { get; set; }
}
