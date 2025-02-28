using System.ComponentModel.DataAnnotations;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.User;

namespace APPLICATION.Dto.CampusRegistrar;

public class CampusRegistrarDto
{
    public int Id { get; set; }

    // Fk User
    public string UserId { get; set; }

    // Fk Campus
    public int CampusId { get; set; }
}
