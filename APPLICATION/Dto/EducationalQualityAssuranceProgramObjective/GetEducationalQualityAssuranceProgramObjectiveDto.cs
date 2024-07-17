using APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceProgramObjective;
public class GetEducationalQualityAssuranceProgramObjectiveDto
{
    public int Id { get; set; }
    public string EqaProgramObjective { get; set; }

    // Fk EducationalQualityAssuranceEducationalGoal
    public int EqaEducationalGoalId { get; set; }
    public GetEducationalQualityAssuranceEducationalGoalDto EqaEducationalGoal { get; set; }
}
