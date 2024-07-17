using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioDisciplinaryAction;
public class PortfolioDisciplinaryActionDto
{
    public PortfolioDisciplinaryActionType ActionType { get; set; }
    public string ActionDetails { get; set; }
    public PortfolioDisciplinaryActionStatus Status { get; set; }
    public DateTime PostedDateTime { get; set; }

    // public string ActionFiles { get; set; }

    // Fk PortfolioIncident 
    public int PortfolioIncidentId { get; set; }

    // Fk User
    public string ImposedByUserId { get; set; }
}
