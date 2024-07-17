using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace DOMAIN.Model;

public class GradeBookItem
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }
    // Fk GradeBook
    public int GradeBookId { get; set; }
    public GradeBook GradeBook { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GradingPeriod GradingPeriod { get; set; }
}