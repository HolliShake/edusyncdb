namespace DOMAIN.Model;

public class EducationalQualityAssuranceProgramObjective
{
    public int Id { get; set; }
    public string EqaProgramObjective { get; set; }
    // Fk EducationalQualityAssuranceEducationalGoal
    public int EqaEducationalGoalId { get; set; }
    public EducationalQualityAssuranceEducationalGoal EqaEducationalGoal { get; set; }
}