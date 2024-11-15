using APPLICATION.Dto.College;
using APPLICATION.Dto.User;

namespace APPLICATION.Dto.CollegeDean;

public class GetCollegeDeanDto
{
    public int Id { get; set; }
    // Fk College
    public int CollegeId { get; set; }
    public GetCollegeDto College { get; set; }

    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }
}
