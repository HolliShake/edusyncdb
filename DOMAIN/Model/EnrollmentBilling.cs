using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class EnrollmentBilling
{
    public int Id { get; set; }
    public string BillingReferenceNumber { get; set; }
    public string BillingParticulars { get; set; }
    public DateTime BillingDateTime { get; set; }
    public DateTime DueDate { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Debit { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Credit { get; set; }

    public bool IsPosted { get; set; }
    public string BillingStatus { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    // Fk EnrollmentFee
    public int EnrollmentFeeId { get; set; }
    public EnrollmentFee EnrollmentFee { get; set; }

    // Fk Cycle
    public int CycleId { get; set; }
    public Cycle Cycle { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }
    public Voucher Voucher { get; set; }
}