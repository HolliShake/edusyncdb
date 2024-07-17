using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class Voucher
{
    public int Id { get; set; }
    public string VoucherName { get; set; }
    public string VoucherCode { get; set; }
    public string VoucherDescription { get; set; }
    public string VoucherType { get; set; }
    public bool IsPercentage { get; set; }
    public bool IsEnabled { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal DefaultAmount { get; set; }
    public string VoucherCriteria { get; set; }
    public DateTime ExpiryDateTime { get; set; }
}