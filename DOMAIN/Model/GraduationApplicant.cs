using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class GraduationApplicant
{
    public int Id { get; set; }

    public bool IsGraduated { get; set; }
    public bool IsAbsentDuringGraduation { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime ApplicationDate { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public AcademicProgram AcademicProgram { get; set; }

    // Fk User
    [ForeignKey("GraduatingStudent")]
    public string GraduatingStudentId { get; set; }
    public User GraduatingStudent { get; set; }

    // Fk GraduationCampus
    public int GraduationCampusId { get; set; }
    public GraduationCampus GraduationCampus { get; set; }
}