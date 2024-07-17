using APPLICATION.Dto.GradeBook;
using APPLICATION.Dto.GradingPeriod;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItem;
public class GetGradeBookItemDto
{
    public int Id { get; set; }

    public decimal Weight { get; set; }
    // Fk GradeBook
    public int GradeBookId { get; set; }
    public GetGradeBookDto GradeBook { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GetGradingPeriodDto GradingPeriod { get; set; }
}
