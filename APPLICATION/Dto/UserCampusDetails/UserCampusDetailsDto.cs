using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserCampusDetails;
public class UserCampusDetailsDto
{
    // Fk User
    public string UserId { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
}
