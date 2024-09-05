namespace DOMAIN.Model;

public class UserCampusDetails
{
    public int Id { get; set; }
    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public Campus Campus { get; set; }
}