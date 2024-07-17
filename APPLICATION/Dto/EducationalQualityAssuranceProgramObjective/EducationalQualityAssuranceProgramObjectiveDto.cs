using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
public class EducationalQualityAssuranceProgramObjectiveDto
{
    public string EqaProgramObjective { get; set; }
    // Fk EducationalQualityAssuranceEducationalGoal
    public int EqaEducationalGoalId { get; set; }
}
