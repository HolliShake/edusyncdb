
namespace DOMAIN.Model;

public class Cycle
{
    public int Id { get; set; }
    public string CycleDescription { get; set; }
    public int CycleNumber { get; set; }
    public string SchoolYear { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    // Fk Campus
    public int CampusId { get; set; }
    public Campus Campus { get; set; }
}