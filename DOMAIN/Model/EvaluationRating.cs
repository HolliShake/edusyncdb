namespace DOMAIN.Model;

public class EvaluationRating
{
    public int Id { get; set; }
    public string OverallComment { get; set; }
    public bool IsPosted { get; set; }
    public DateTime RatingDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    // Fk EvaluationPeriod
    public int EvaluationPeriodId { get; set; }
    public EvaluationPeriod EvaluationPeriod { get; set; }

    // Fk ScheduleTeacher
    public int ScheduleTeacherId { get; set; }
    public ScheduleTeacher ScheduleTeacher { get; set; }

    // Fk
    public ICollection<EvaluationRatingDetail> EvaluationRatingDetails { get; set; }
}