namespace DOMAIN.Model;

public class EducationalQualityAssuranceLearningObjective
{
    public int Id { get; set; }
    public string EqaLearningObjective { get; set; }

    // Fk CourseObjective
    public int EqaCourseObjectiveId { get; set; }
    public EducationalQualityAssuranceCourseObjective EqaCourseObjective { get; set; }
}