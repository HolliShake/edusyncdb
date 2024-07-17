using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class Enrollment
{
    public int Id { get; set; }
    public int EnrollmentDateTime { get; set; }
    public int YearLEvel { get; set; }
    [Column(TypeName = "decimal(18,0)")]
    public decimal CreditUnits { get; set; }
    public string GradeOverallStatus { get; set; }
    public string GradeRemarks { get; set; }
    public string EnrollmentStatus { get; set; }
    public string EnrollmentNotes { get; set; }
    public bool IsValidated { get; set; }
    public DateTime LastUpdatedDateTime { get; set; }

    // Fk User (student)
    [ForeignKey("StudentUser")]
    public string StudentUserId { get; set; }
    public User StudentUser { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public EnrollmentRole EnrollmentRole { get; set; }
}