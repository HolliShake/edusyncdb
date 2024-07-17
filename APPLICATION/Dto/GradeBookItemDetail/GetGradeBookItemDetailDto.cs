using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.Dto.GradeBookItem;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItemDetail;
public class GetGradeBookItemDetailDto
{
    public int Id { get; set; }
    public string ItemDetail { get; set; }
    public string ItemDetailDescription { get; set; }
    public decimal MaxScore { get; set; }
    public decimal PassingScore { get; set; }
    public decimal Weight { get; set; }

    // Fk GradeBookItem
    public int GradeBookItemId { get; set; }
    public GetGradeBookItemDto GradeBookItem { get; set; }

    // Fk EducationalQualityAssuranceAssessmentType
    public int EqaAssessmentTypeId { get; set; }
    public GetEducationalQualityAssuranceAssessmentTypeDto EqaAssessmentType { get; set; }
}
