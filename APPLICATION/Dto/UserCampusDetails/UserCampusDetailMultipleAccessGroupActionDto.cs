using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.UserCampusDetails;

public class UserCampusDetailMultipleAccessGroupActionDto
{
    [Required]
    public string UserId { get; set; }
    [Required]
    public int[] AccessGroupActionIds { get; set; }
}