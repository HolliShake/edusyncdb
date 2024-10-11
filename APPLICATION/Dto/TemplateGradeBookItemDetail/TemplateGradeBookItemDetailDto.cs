using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.TemplateGradeBookItemDetail;
public class TemplateGradeBookItemDetailDto
{
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

    // Fk EducationalQualityAssuranceAssessmentType
    public int EqaAssessmentTypeId { get; set; }
}
