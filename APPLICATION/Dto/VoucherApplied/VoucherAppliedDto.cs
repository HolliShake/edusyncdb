namespace APPLICATION.Dto.VoucherApplied;
public class VoucherAppliedDto
{
    public decimal Amount { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }

    // Fk EnrollmentBilling
    public int EnrollmentBillingId { get; set; }
}
