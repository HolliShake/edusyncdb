using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItem;
public class GradeBookItemDto
{
    public int Id { get; set; }

    public decimal Weight { get; set; }

    // Fk GradeBook
    public int GradeBookId { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
}