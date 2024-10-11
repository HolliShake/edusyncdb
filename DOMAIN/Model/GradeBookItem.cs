using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
namespace DOMAIN.Model;

public class GradeBookItem
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }
    // Fk GradeBook
    [ForeignKey("GradeBook")]
    public int GradeBookId { get; set; }
    public GradeBook GradeBook { get; set; }
    // Fk GradingPeriod
    [ForeignKey("GradingPeriod")]
    public int GradingPeriodId { get; set; }
    public GradingPeriod GradingPeriod { get; set; }
    // Nav
    public ICollection<GradeBookItemDetail> GradeBookItemDetails { get; set; }
}