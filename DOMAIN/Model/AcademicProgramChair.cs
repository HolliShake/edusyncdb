namespace DOMAIN.Model;

public class AcademicProgramChair
{
    public int Id { get; set; }
    
    // Fk Academic Program
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }

}