namespace DOMAIN.Model;


public class Campus
{
    public int Id { get; set; }
    public string CampusName { get; set; }
    public string Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    // Fk Agency
    public int AgencyId { get; set; }
    public Agency Agency { get; set; }
}