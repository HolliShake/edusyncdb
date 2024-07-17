using APPLICATION.Dto.PortfolioSession;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioSessionInvolved;
public class GetPortfolioSessionInvolvedDto
{
    public int Id { get; set; }
    public string RoleDescripton { get; set; }

    // Fk PortfolioSession
    public int PortfolioSessionId { get; set; }
    public GetPortfolioSessionDto PortfolioSession { get; set; }

    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }
}
