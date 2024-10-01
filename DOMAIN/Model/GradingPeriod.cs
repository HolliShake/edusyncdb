using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class GradingPeriod
{
    public int Id { get; set; }
    public string GradingPeriodDescription { get; set; }
    public int GradingNumber { get; set; }
    // Fk
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public College Department { get; set; }
}