
namespace DOMAIN.Model;

public class AcademicProgram
{
    public int Id { get; set; }
    public string ProgramName { get; set; }
    public string ShortName { get; set; }
    public DateTime YearFirstImplemented { get; set; }

    // Fk College
    public int CollegeId { get; set; }
    public College College { get; set; }
}