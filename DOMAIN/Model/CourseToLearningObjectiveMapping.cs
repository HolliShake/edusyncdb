namespace DOMAIN.Model;

public class CourseToLearningObjectiveMapping
{
    public int Id { get; set; }

    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }

    // Fk LearningObjective
    public int LearningObjectiveId { get; set; }
    public EducationalQualityAssuranceLearningObjective EducationalQualityAssuranceLearningObjective { get; set; }
}