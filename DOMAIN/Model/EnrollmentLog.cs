namespace DOMAIN.Model;

public class EnrollmentLog
{
    public int Id { get; set; }
    public DateTime LogDate { get; set; }
    public string LogDescription { get; set; }
    public string NetworkAddress { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    // Fk User
    public string LogByUserId { get; set; }
    public User LogByUser { get; set; }
}