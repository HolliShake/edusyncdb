using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.CollegeDean;

public class CollegeDeanDto
{
    // Fk College
    public int CollegeId { get; set; }

    // Fk User
    public string UserId { get; set; }
}
