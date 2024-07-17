using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
public class EducationalQualityAssuranceEducationalGoalDto
{
    public string EqaGoal { get; set; }
    // Fk 
    public int EqaTypeId { get; set; }
}
