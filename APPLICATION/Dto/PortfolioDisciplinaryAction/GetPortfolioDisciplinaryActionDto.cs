using APPLICATION.Dto.PortfolioIncident;
using APPLICATION.Dto.User;
using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioDisciplinaryAction;
public class GetPortfolioDisciplinaryActionDto
{
    public int Id { get; set; }
    public PortfolioDisciplinaryActionType ActionType { get; set; }
    public string ActionDetails { get; set; }
    public PortfolioDisciplinaryActionStatus Status { get; set; }
    public DateTime PostedDateTime { get; set; }

    // public string ActionFiles { get; set; }

    // Fk PortfolioIncident 
    public int PortfolioIncidentId { get; set; }
    public GetPortfolioIncidentDto PortfolioIncident { get; set; }

    // Fk User
    public string ImposedByUserId { get; set; }
    public GetUserOnlyDto ImposedByUser { get; set; }
}
