using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class GradeInput
{
    public int Id { get; set; }
    public string GradeInputType { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal NumericGrade { get; set; }
    public string LetterGrade { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal StartRange { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal EndRange { get; set; }
    public string GradeRemarks { get; set; }
    public string GradeDescription { get; set; }
}