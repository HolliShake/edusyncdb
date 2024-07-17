using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioEntry;
public class PortfolioEntryDto
{
    public string PortfolioTitle { get; set; }
    public string PortfolioDescription { get; set; }
    public string PortfolioReferenceNumber { get; set; }
    public string MentorOrAdviser { get; set; }
    public decimal CreditPoints { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    // Fk User
    public string UserId { get; set; }

    // Fk PortfolioProvider
    public int PortfolioProviderId { get; set; }

    // Fk PortfolioScope
    public int PortfolioScopeId { get; set; }

    // Fk PortfolioType
    public int PortfolioTypeId { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
}
