using System.ComponentModel.DataAnnotations;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.User;

namespace APPLICATION.Dto.UserCampusDetails;
public class GetUserCampusDetailsDto
{
    public int Id { get; set; }
    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
    public GetCampusDto Campus { get; set; }
}
