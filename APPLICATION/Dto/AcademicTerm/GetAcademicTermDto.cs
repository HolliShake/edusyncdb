using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicTerm;
public class GetAcademicTermDto
{
    public int Id { get; set; }
    public string AcademicTermDescription { get; set; }
    public int NumberOfGradingPeriod { get; set; }
    public string Label { get; set; }
}
