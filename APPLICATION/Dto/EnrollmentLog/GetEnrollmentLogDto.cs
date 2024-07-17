using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentLog;
public class GetEnrollmentLogDto
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string LogDescription { get; set; }
    public string NetworkAddress { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public GetEnrollmentLogDto Enrollment { get; set; }

    // Fk User
    public string LogByUserId { get; set; }
    public GetUserOnlyDto LogByUser { get; set; }
}
