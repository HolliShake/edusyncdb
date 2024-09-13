using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.GradeInput;
using APPLICATION.Dto.GradingPeriod;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.EnrollmentGrade;
public class GetEnrollmentGradeDto
{
    public int Id { get; set; }
    public bool IsPosted { get; set; }
    public string GradeStatus { get; set; }
    public string GradeNotes { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime UpdatedDateTime { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public GetEnrollmentDto Enrollment { get; set; }

    // Fk GradingInput
    public int GradeInputId { get; set; }
    public GetGradeInputDto GradeInput { get; set; }

    // Fk GradingPeriod
    public int GradingPeriodId { get; set; }
    public GetGradingPeriodDto GradingPeriod { get; set; }

    // Fk User
    public string EncodedByUserId { get; set; }
    public GetUserOnlyDto EncodedByUser { get; set; }
}
