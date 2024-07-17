using APPLICATION.Dto.EducationalQualityAssuranceType;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceEducationalGoal;
public class GetEducationalQualityAssuranceEducationalGoalDto
{
    public int Id { get; set; }
    public string EqaGoal { get; set; }
    // Fk 
    public int EqaTypeId { get; set; }
    public GetEducationalQualityAssuranceTypeDto EqaType { get; set; }
}
