using APPLICATION.Dto.PortfolioProvider;
using APPLICATION.Dto.PortfolioScope;
using APPLICATION.Dto.PortfolioType;
using APPLICATION.Dto.SkillsFrameworkProficiencyLevel;
using APPLICATION.Dto.SkillsFrameworkSkills;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioEntry;
public class GetPortfolioEntryDto
{
    public int Id { get; set; }
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
    public GetUserOnlyDto User { get; set; }

    // Fk PortfolioProvider
    public int PortfolioProviderId { get; set; }
    public GetPortfolioProviderDto PortfolioProvider { get; set; }

    // Fk PortfolioScope
    public int PortfolioScopeId { get; set; }
    public GetPortfolioScopeDto PortfolioScope { get; set; }

    // Fk PortfolioType
    public int PortfolioTypeId { get; set; }
    public GetPortfolioTypeDto PortfolioType { get; set; }

    // Fk SkillsFrameworkSkills
    public int SfSkillsId { get; set; }
    public GetSkillsFrameworkSkillsDto SfSkills { get; set; }

    // Fk SkillsFrameworkProficiencyLevel
    public int SfProficiencyLevelId { get; set; }
    public GetSkillsFrameworkProficiencyLevelDto SfProficiencyLevel { get; set; }
}
