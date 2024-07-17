namespace DOMAIN.Model;

public class SkillsFrameworkJobRole
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string JobDescription { get; set; }

    // Fk Track
    public int SfTrackSpecializationId { get; set; }
    public SkillsFrameworkTrackSpecialization SfTrackSpecialization { get; set; }
}