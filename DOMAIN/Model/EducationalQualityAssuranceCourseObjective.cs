namespace DOMAIN.Model;

public class EducationalQualityAssuranceCourseObjective
{
    public int Id { get; set; }
    public string EqaCourseObjective { get; set; }

    // Fk EQAProgramObjective
    public int EqaProgramObjectiveId { get; set; }
    public EducationalQualityAssuranceProgramObjective EqaProgramObjective { get; set; }
}