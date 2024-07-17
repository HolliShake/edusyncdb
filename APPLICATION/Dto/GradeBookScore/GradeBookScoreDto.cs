using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookScore;
public class GradeBookScoreDto
{
    public decimal Score { get; set; }

    // Fk GradeBookItemDetails
    public int GradeBookItemDetailId { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
}
