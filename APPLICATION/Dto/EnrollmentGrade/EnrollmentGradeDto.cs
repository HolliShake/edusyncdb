using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.EnrollmentGrade;
public class EnrollmentGradeDto
{
    [Required]
    public bool IsPosted { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(75)]
    public string GradeStatus { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(255)]
    public string GradeNotes { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; }

    // Fk Enrollment
    [Required]
    public int EnrollmentId { get; set; }

    // Fk GradingInput
    [Required]
    public int GradingInputId { get; set; }

    // Fk GradingPeriod
    [Required]
    public int GradingPeriodId { get; set; }

    // Fk User
    public string EncodedByUserId { get; set; }
}
