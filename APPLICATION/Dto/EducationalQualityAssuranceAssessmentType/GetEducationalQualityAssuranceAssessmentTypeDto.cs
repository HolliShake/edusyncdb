using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
public class GetEducationalQualityAssuranceAssessmentTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
