namespace DOMAIN.Model;

public class PortfolioSessionInvolved
{
    public int Id { get; set; }
    public string RoleDescripton { get; set; }

    // Fk PortfolioSession
    public int PortfolioSessionId { get; set; }
    public PortfolioSession PortfolioSession { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }
}