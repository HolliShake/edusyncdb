

namespace DOMAIN.Model;

public class SpecializationChair
{
    public int Id { get; set; }

    // Fk TrackSpecialization
    public int SFTrackSpecializationId { get; set; }
    public SkillsFrameworkTrackSpecialization SFTrackSpecialization { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }
}