namespace DOMAIN.Model;

public class CourseFee
{
    public int Id { get; set; }
    // Fk Course
    public int CourseId { get; set; }
    public Course Course { get; set; }
    // FK Fee
    public int FeeId { get; set; }
    public EnrollmentFee Fee { get; set; }
}