using APPLICATION.Dto.GradingPeriod;
using APPLICATION.Dto.TemplateGradeBook;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.TemplateGradeBookItem;
public class GetTemplateGradeBookItemDto
{
    public int Id { get; set; }
    public string ItemName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Weight { get; set; }
    // Fk GradeBook
    public int TemplateGradeBookId { get; set; }
    public GetTemplateGradeBookDto TemplateGradeBook { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GetGradingPeriodDto GradingPeriod { get; set; }
}
