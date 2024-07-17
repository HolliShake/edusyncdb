namespace DOMAIN.Model;

public class PortfolioProvider
{
    public int Id { get; set; }
    public string ProviderName { get; set; }
    public string ProviderAddress { get; set; }
    public string Authority { get; set; }
    public string ContractName { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }

    // Fk SectorDiscipline
    public int SectorDisciplineId { get; set; }
    public SectorDiscipline SectorDiscipline { get; set; }
}