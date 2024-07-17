using APPLICATION.Dto.PortfolioSessionType;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioSession;
public class GetPortfolioSessionDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string ReferenceTag { get; set; }
    public string ReferenceTagType { get; set; }
    public string SessionSummaryText { get; set; }
    public bool IsPosted { get; set; }
    public DateTime PostedDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime FollowupDateTime { get; set; }
    public DateTime SessionStartDateTime { get; set; }
    public DateTime SessionEndDateTime { get; set; }
    // Fk
    public int PortfolioSessionTypeId { get; set; }
    public GetPortfolioSessionTypeDto PortfolioSessionType { get; set; }
}
