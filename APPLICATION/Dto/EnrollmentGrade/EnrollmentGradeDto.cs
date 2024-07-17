using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentGrade;
public class EnrollmentGradeDto
{
    public bool IsPosted { get; set; }
    public string GradeStatus { get; set; }
    public string GradeNotes { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }

    // Fk GradingInput
    public int GradingInput { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
}
