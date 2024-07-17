using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleTeacher;
public class ScheduleTeacherDto
{
    // Fk User
    public string TeacherUserId { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
}
