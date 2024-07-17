using APPLICATION.Dto.EnrollmentRole;
using APPLICATION.Dto.Schedule;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ScheduleTeacher;
public class GetScheduleTeacherDto
{
    public int Id { get; set; }

    // Fk User
    public string TeacherUserId { get; set; }
    public GetUserOnlyDto TeacherUser { get; set; }

    // Fk EnrollmentRole
    public int EnrollmentRoleId { get; set; }
    public GetEnrollmentRoleDto EnrollmentRole { get; set; }

    // Fk Schedule
    public int ScheduleId { get; set; }
    public GetScheduleDto Schedule { get; set; }
}
