using APPLICATION.Dto.College;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AcademicProgram;
public class GetAcademicProgramDto
{
    public int Id { get; set; }
    public string ProgramName { get; set; }
    public string ShortName { get; set; }
    public DateTime YearFirstImplemented { get; set; }

    // Fk College
    public int CollegeId { get; set; }
    public GetCollegeDto College { get; set; }
}
