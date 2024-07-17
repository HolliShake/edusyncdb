using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.PortfolioProvider;
public class PortfolioProviderDto
{
    public string ProviderName { get; set; }
    public string ProviderAddress { get; set; }
    public string Authority { get; set; }
    public string ContractName { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
}
