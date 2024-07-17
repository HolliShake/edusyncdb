using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.BulletinScope;
public class BulletinScopeDto
{
    // FK Bulletin
    public int BulletinId { get; set; }
    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
}
