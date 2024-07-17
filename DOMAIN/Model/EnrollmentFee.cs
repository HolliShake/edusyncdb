
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class EnrollmentFee
{
    public int Id { get; set; }
    public string FeeName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal DefaultAmount { get; set; }
    public string FeeCategory { get; set; }
    // Fk TableObject
    public int ObjectId { get; set; }
    public TableObject Object { get; set; }
    // Fk FundSource
    public int FundSourceId { get; set; }
    public FundSource FundSource { get; set; }
}