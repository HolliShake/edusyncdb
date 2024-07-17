using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GraduationApplicant;
public class GraduationApplicantDto
{
    public bool IsGraduated { get; set; }
    public bool IsAbsentDuringGraduation { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime ApplicationDate { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }

    // Fk User
    public string GraduatingStudentId { get; set; }

    // Fk GraduationCampus
    public int GraduationCampusId { get; set; }
}
