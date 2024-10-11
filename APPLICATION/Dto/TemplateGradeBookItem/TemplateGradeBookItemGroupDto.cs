using APPLICATION.Dto.TemplateGradeBookItemDetail;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.TemplateGradeBookItem;

public class TemplateGradeBookItemGroupDto
{
    public string ItemName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }

    public TemplateGradeBookItemDetailGroupDto[] TemplateGradeBookItemDetails { get; set; }
}