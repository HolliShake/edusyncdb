
namespace DOMAIN.Model;

public class College
{
    public int Id { get; set; }
    public string CollegeName { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public Campus Campus { get; set; }
}