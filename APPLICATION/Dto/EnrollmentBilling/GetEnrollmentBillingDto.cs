using APPLICATION.Dto.EnrollmentFee;
using APPLICATION.Dto.Voucher;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentBilling;
public class GetEnrollmentBillingDto
{
    public int Id { get; set; }
    public string BillingReferenceNumber { get; set; }
    public string BillingParticulars { get; set; }
    public DateTime BillingDateTime { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }

    public bool IsPosted { get; set; }
    public string BillingStatus { get; set; }

    // Fk Enrollment
    public int EnrollmentId { get; set; }
    public GetEnrollmentFeeDto Enrollment { get; set; }

    // Fk EnrollmentFee
    public int EnrollmentFeeId { get; set; }
    public GetEnrollmentFeeDto EnrollmentFee { get; set; }

    // Fk Voucher
    public int VoucherId { get; set; }
    public GetVoucherDto Voucher { get; set; }
}
