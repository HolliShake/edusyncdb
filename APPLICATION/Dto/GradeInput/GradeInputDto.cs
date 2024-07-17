using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.GradeInput;
public class GradeInputDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string GradeInputType { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal NumericGrade { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(5)]
    public string LetterGrade { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal StartRange { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal EndRange { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(75)]
    public string GradeRemarks { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    public string GradeDescription { get; set; }
}
