using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ScheduleTeacher
{
    public int Id { get; set; }

    // Fk User
    [ForeignKey("TeacherUser")]
    public string TeacherUserId { get; set; }
    public User TeacherUser { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public EnrollmentRole EnrollmentRole { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}