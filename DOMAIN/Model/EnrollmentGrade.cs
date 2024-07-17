namespace DOMAIN.Model;

public class EnrollmentGrade
{
    public int Id { get; set; }
    public bool IsPosted { get; set; }
    public string GradeStatus { get; set; }
    public string GradeNotes { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    // Fk GradingInput
    public int GradingInput { get; set; }
    public GradeInput GradeInput { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GradingPeriod GradingPeriod { get; set; }
}