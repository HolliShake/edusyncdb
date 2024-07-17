using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class PortfolioEntry
{
    public int Id { get; set; }
    public string PortfolioTitle { get; set; }
    public string PortfolioDescription { get; set; }
    public string PortfolioReferenceNumber { get; set; }
    public string MentorOrAdviser { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal CreditPoints { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }

    // Fk PortfolioProvider
    public int PortfolioProviderId { get; set; }
    public PortfolioProvider PortfolioProvider { get; set; }

    // Fk PortfolioScope
    public int PortfolioScopeId { get; set; }
    public PortfolioScope PortfolioScope { get; set; }

    // Fk PortfolioType
    public int PortfolioTypeId { get; set; }
    public PortfolioType PortfolioType { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public SkillsFrameworkSkills SfSkills { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public SkillsFrameworkProficiencyLevel SfProficiencyLevel { get; set; }
}