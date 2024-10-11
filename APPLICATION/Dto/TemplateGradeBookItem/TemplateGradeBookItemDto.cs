using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.TemplateGradeBookItem;
public class TemplateGradeBookItemDto
{
    public string ItemName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }
    // Fk GradeBook
    public int TemplateGradeBookId { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
}
