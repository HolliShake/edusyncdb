using APPLICATION.Dto.PortfolioIncidentType;
using APPLICATION.Dto.User;
using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioIncident;
public class GetPortfolioIncidentDto
{
    public int Id { get; set; }
    public string IncidentText { get; set; }
    public string ResolutionText { get; set; }
    public bool IsPosted { get; set; }
    public DateTime IncidentDate { get; set; }
    public DateTime PostedDateTime { get; set; }
    public PortfolioIncidentStatus Status { get; set; }
    // public string ResolutionFiles { get; set; }
    // public string ComplaintFiles { get; set; }

    // Fk User
    public string ComplaineeUserId { get; set; }
    public GetUserOnlyDto ComplaineeUser { get; set; }

    // Fk User
    public string ComplainantUserId { get; set; }
    public GetUserOnlyDto ComplainantUser { get; set; }

    // Fk User
    public string EncodedByUserId { get; set; }
    public GetUserOnlyDto EncodedByUser { get; set; }

    // Fk PortfolioIncidentType
    public int PortfolioIncidentTypeId { get; set; }
    public GetPortfolioIncidentTypeDto PortfolioIncidentType { get; set; }
}
