using APPLICATION.Dto.Course;
using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseToLearningObjectiveMapping;
public class GetCourseToLearningObjectiveMappingDto
{
    public int Id { get; set; }

    // Fk Course
    public int CourseId { get; set; }
    public GetCourseDto Course { get; set; }

    // Fk LearningObjective
    public int LearningObjectiveId { get; set; }
    public GetEducationalQualityAssuranceLearningObjectiveDto EducationalQualityAssuranceLearningObjective { get; set; }
}
