using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Enrollment;
public class EnrollmentDto
{
    public DateTime EnrollmentDateTime { get; set; }
    public int YearLevel { get; set; }
    public decimal CreditUnits { get; set; }
    public string GradeOverallStatus { get; set; }
    public string GradeRemarks { get; set; }
    public string EnrollmentStatus { get; set; }
    public string EnrollmentNotes { get; set; }
    public bool IsValidated { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }

    // Fk User (student)
    public string StudentUserId { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
}
