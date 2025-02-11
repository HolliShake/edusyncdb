using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SpecializationChair;
public class SpecializationChairDto
{
    // Fk TrackSpecialization
    public int SFTrackSpecializationId { get; set; }

    // Fk User
    [Required]
    public string UserId { get; set; }
}
