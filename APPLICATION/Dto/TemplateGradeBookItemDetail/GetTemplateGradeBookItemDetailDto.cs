using APPLICATION.Dto.EducationalQualityAssuranceAssessmentType;
using APPLICATION.Dto.TemplateGradeBookItem;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.TemplateGradeBookItemDetail;
public class GetTemplateGradeBookItemDetailDto
{
    public int Id { get; set; }
    public string ItemDetail { get; set; }
    public string ItemDetailDescription { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal MaxScore { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal PassingScore { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }

    // Fk GradeBookItem
    public int TemplateGradeBookItemId { get; set; }
    public GetTemplateGradeBookItemDto TemplateGradeBookItem { get; set; }

    // Fk EducationalQualityAssuranceAssessmentType
    public int EqaAssessmentTypeId { get; set; }
    public GetEducationalQualityAssuranceAssessmentTypeDto EqaAssessmentType { get; set; }
}
