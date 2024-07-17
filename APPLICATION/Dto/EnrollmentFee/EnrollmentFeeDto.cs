using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.EnrollmentFee;
public class EnrollmentFeeDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string FeeName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal DefaultAmount { get; set; }
    [Required]
    [MinLength(4)]
    [MaxLength(25)]
    public string FeeCategory { get; set; }
    // Fk TableObject
    [Required]
    public int ObjectId { get; set; }
    // Fk FundSource
    [Required]
    public int FundSourceId { get; set; }
}
