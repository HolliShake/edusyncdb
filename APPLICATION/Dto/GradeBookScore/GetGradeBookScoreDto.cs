using APPLICATION.Dto.Enrollment;
using APPLICATION.Dto.GradeBookItemDetail;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookScore;
public class GetGradeBookScoreDto
{
    public int Id { get; set; }
    public decimal Score { get; set; }

    // Fk GradeBookItemDetails
    public int GradeBookItemDetailId { get; set; }
    public GetGradeBookItemDetailDto GradeBookitemDetail { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public GetEnrollmentDto Enrollment { get; set; }
}
