using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItemDetail;
public class GradeBookItemDetailDto
{
    public string ItemDetail { get; set; }
    public string ItemDetailDescription { get; set; }
    public decimal MaxScore { get; set; }
    public decimal PassingScore { get; set; }
    public decimal Weight { get; set; }

    // Fk GradeBookItem
    public int GradeBookItemId { get; set; }

    // Fk EducationalQualityAssuranceAssessmentType
    public int EqaAssessmentTypeId { get; set; }
}
