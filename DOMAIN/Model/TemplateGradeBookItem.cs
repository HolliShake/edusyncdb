using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class TemplateGradeBookItem
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }
    // Fk GradeBook
    public int TemplateGradeBookId { get; set; }
    public TemplateGradeBook TemplateGradeBook { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GradingPeriod GradingPeriod { get; set; }
}