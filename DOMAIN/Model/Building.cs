namespace DOMAIN.Model;

public class Building
{
    public int Id { get; set; }
    public string BuildingName { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public Campus Campus { get; set; }
}