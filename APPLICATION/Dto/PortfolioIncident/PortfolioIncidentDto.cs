using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioIncident;
public class PortfolioIncidentDto
{
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

    // Fk User
    public string ComplainantUserId { get; set; }

    // Fk User
    public string EncodedByUserId { get; set; }

    // Fk PortfolioIncidentType
    public int PortfolioIncidentTypeId { get; set; }
}
