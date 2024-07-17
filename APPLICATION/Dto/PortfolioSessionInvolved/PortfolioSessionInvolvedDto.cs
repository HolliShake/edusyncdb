using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioSessionInvolved;
public class PortfolioSessionInvolvedDto
{
    public string RoleDescripton { get; set; }

    // Fk PortfolioSession
    public int PortfolioSessionId { get; set; }

    // Fk User
    public string UserId { get; set; }
}
