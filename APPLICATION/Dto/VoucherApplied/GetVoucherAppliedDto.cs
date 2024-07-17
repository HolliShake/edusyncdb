using APPLICATION.Dto.EnrollmentBilling;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.VoucherApplied;
public class GetVoucherAppliedDto
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }
    public GetVoucherAppliedDto Voucher { get; set; }

    // Fk EnrollmentBilling
    public int EnrollmentBillingId { get; set; }
    public GetEnrollmentBillingDto EnrollmentBilling { get; set; }
}
