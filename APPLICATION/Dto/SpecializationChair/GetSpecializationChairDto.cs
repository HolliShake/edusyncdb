using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SpecializationChair;
public class GetSpecializationChairDto
{
    public int Id { get; set; }

    // Fk TrackSpecialization
    public int SFTrackSpecializationId { get; set; }
    public GetSkillsFrameworkTrackSpecializationDto SFTrackSpecialization { get; set; }

    // Fk User
    public string UserId { get; set; }
    public GetUserOnlyDto User { get; set; }
}
