using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EnrollmentPayment;
public class EnrollmentPaymentDto
{
    public DateTime PaymentDateTime { get; set; }
    public string ORNumber { get; set; }
    public decimal Amount { get; set; } 
    public string PaymentDescription { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    // Fk EnrollmentBilling
    public int EnrollmentBillingId { get; set; }

    // Fk User (cashier)
    public string CashierId { get; set; }
}
