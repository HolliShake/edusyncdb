using APPLICATION.Dto.FundSource;
using APPLICATION.Dto.TableObject;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.EnrollmentFee;
public class GetEnrollmentFeeDto
{
    public int Id { get; set; }
    public string FeeName { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal DefaultAmount { get; set; }
    public string FeeCategory { get; set; }
    // Fk TableObject
    public int ObjectId { get; set; }
    public GetTableObjectDto Object { get; set; }
    // Fk FundSource
    public int FundSourceId { get; set; }
    public GetFundSourceDto FundSource { get; set; }
}
