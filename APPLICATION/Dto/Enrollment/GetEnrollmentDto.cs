using APPLICATION.Dto.EnrollmentRole;
using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Enrollment;
public class GetEnrollmentDto
{
    public int Id { get; set; }
    public int EnrollmentDateTime { get; set; }
    public int YearLEvel { get; set; }
    public decimal CreditUnits { get; set; }
    public string GradeOverallStatus { get; set; }
    public string GradeRemarks { get; set; }
    public string EnrollmentStatus { get; set; }
    public string EnrollmentNotes { get; set; }
    public bool IsValidated { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }

    // Fk User (student)
    public string StudentUserId { get; set; }
    public GetUserOnlyDto StudentUser { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public GetEnrollmentRoleDto EnrollmentRole { get; set; }
}
