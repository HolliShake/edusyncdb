using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Bulletin;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.BulletinScope;
public class GetBulletinScopeDto
{
    public int Id { get; set; }
    // FK Bulletin
    public int BulletinId { get; set; }
    public GetBulletinDto Bulletin { get; set; }
    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }
}
