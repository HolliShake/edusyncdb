using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class GradeBookScore
{
    public int Id { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Score { get; set; }

    // Fk GradeBookItemDetails
    public int GradeBookItemDetailId { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }
}