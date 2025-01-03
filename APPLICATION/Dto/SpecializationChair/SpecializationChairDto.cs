using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SpecializationChair;
public class SpecializationChairDto
{
    public int Id { get; set; }

    // Fk TrackSpecialization
    public int SFTrackSpecializationId { get; set; }

    // Fk User
    [Required]
    public string UserId { get; set; }
}
