using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CourseToLearningObjectiveMapping;
public class CourseToLearningObjectiveMappingDto
{
    // Fk Course
    public int CourseId { get; set; }

    // Fk LearningObjective
    public int LearningObjectiveId { get; set; }
}
