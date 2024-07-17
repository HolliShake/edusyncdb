using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Voucher;
public class GetVoucherDto
{
    public int Id { get; set; }
    public string VoucherName { get; set; }
    public string VoucherCode { get; set; }
    public string VoucherDescription { get; set; }
    public string VoucherType { get; set; }
    public bool IsPercentage { get; set; }
    public bool IsEnabled { get; set; }
    public decimal DefaultAmount { get; set; }
    public string VoucherCriteria { get; set; }
    public DateTime ExpiryDateTime { get; set; }
}
