using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.User;

namespace APPLICATION.Dto.AcademicProgramChair;
public class GetAcademicProgramChairDto
{
    public int Id { get; set; }
    
    // Fk Academic Program
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }

    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }

}
