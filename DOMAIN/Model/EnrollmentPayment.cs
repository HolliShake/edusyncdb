using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class EnrollmentPayment
{
    public int Id { get; set; }
    public DateTime PaymentDateTime { get; set; }
    public string ORNumber { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Amount { get; set; } 
    public string PaymentDescription { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    // Fk EnrollmentBilling
    public int EnrollmentBillingId { get; set; }
    public EnrollmentBilling EnrollmentBilling { get; set; }

    // Fk User (cashier)
    [ForeignKey("Cashier")]
    public string CashierId { get; set; }
    public User Cashier { get; set; }
}