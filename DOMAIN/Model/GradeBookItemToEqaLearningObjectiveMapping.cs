namespace DOMAIN.Model;

public class GradeBookItemToEqaLearningObjectiveMapping
{
    public int Id { get; set; }

    // Fk GradeBookItemDetail
    public int GradeBookItemDetailId { get; set; }
    public GradeBookItemDetail GradeBookitemDetail { get; set; }

    // Fk EducationalQualityAssuranceLearningObjective
    public int EqaLearningObjectiveId { get; set; }
    public EducationalQualityAssuranceLearningObjective EqaLearningObjective { get; set; }
}