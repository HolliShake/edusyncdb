using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentBilling;
public class EnrollmentBillingDto
{
    public string BillingReferenceNumber { get; set; }
    public string BillingParticulars { get; set; }
    public DateTime BillingDateTime { get; set; }
    public DateTime DueDate { get; set; }

    public decimal Debit { get; set; }

    public decimal Credit { get; set; }

    public bool IsPosted { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }

    // Fk EnrollmentFee
    public int EnrollmentFeeId { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }
}
