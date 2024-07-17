using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.GraduationCampus;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GraduationApplicant;
public class GetGraduationApplicantDto
{
    public int Id { get; set; }
    public bool IsGraduated { get; set; }
    public bool IsAbsentDuringGraduation { get; set; }
    public string ApplicationStatus { get; set; }
    public DateTime ApplicationDate { get; set; }

    // Fk AcademicProgram
    public int AcademicProgramId { get; set; }
    public GetAcademicProgramDto AcademicProgram { get; set; }

    // Fk User
    public string GraduatingStudentId { get; set; }
    public GetUserOnlyDto GraduatingStudent { get; set; }

    // Fk GraduationCampus
    public int GraduationCampusId { get; set; }
    public GetGraduationCampusDto GraduationCampus { get; set; }
}
