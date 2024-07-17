using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentLog;
public class EnrollmentLogDto
{
    public DateTime LogDate { get; set; }
    public string LogDescription { get; set; }
    public string NetworkAddress { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }

    // Fk User
    public string LogByUserId { get; set; }
}
