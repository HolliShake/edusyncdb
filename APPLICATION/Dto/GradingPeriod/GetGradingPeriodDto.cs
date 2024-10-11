using APPLICATION.Dto.College;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradingPeriod;
public class GetGradingPeriodDto
{
    public int Id { get; set; }
    public string GradingPeriodDescription { get; set; }
    public int GradingNumber { get; set; }
    // Fk
    public int CollegeId { get; set; }
    public GetCollegeDto College { get; set; }
}
