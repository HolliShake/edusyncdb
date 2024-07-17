using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class VoucherApplied
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Amount { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }
    public Voucher Voucher { get; set; }

    // Fk EnrollmentBilling
    public int EnrollmentBillingId { get; set; }
    public EnrollmentBilling EnrollmentBilling { get; set; }
}