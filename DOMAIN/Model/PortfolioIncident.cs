using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class PortfolioIncident
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
    [ForeignKey("ComplaineeUser")]
    public string ComplaineeUserId { get; set; }
    public User ComplaineeUser { get; set; }

    // Fk User
    [ForeignKey("ComplainantUser")]
    public string ComplainantUserId { get; set; }
    public User ComplainantUser { get; set; }

    // Fk User
    [ForeignKey("EncodedByUser")]
    public string EncodedByUserId { get; set; }
    public User EncodedByUser { get; set; }

    // Fk PortfolioIncidentType
    public int PortfolioIncidentTypeId { get; set; }
    public PortfolioIncidentType PortfolioIncidentType { get; set; }
}