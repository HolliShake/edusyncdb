namespace DOMAIN.Model;

public class CollegeDean
{
    public int Id { get; set; }
    // Fk College
    public int CollegeId { get; set; }
    public College College { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }
}