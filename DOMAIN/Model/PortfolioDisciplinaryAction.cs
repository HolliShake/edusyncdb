using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class PortfolioDisciplinaryAction
{
    public int Id { get; set; }

    public PortfolioDisciplinaryActionType ActionType { get; set; }
    public string ActionDetails { get; set; }
    public PortfolioDisciplinaryActionStatus Status { get; set; }
    public DateTime PostedDateTime { get; set; }

    // public string ActionFiles { get; set; }

    // Fk PortfolioIncident 
    public int PortfolioIncidentId { get; set; }
    public PortfolioIncident PortfolioIncident { get; set; }

    // Fk User
    [ForeignKey("ImposedByUser")]
    public string ImposedByUserId { get; set; }
    public User ImposedByUser { get; set; }
}