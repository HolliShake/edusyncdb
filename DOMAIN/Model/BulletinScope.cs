namespace DOMAIN.Model;

public class BulletinScope
{
    public int Id { get; set; }
    // FK Bulletin
    public int BulletinId { get; set; }
    public Bulletin Bulletin { get; set; }
    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }
}