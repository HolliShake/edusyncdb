using APPLICATION.Dto.EducationalQualityAssuranceLearningObjective;
using APPLICATION.Dto.GradeBookItemDetail;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItemToEqaLearningObjectiveMapping;
public class GetGradeBookItemToEqaLearningObjectiveMappingDto
{
    public int Id { get; set; }

    // Fk GradeBookItemDetail
    public int GradeBookItemDetailId { get; set; }
    public GetGradeBookItemDetailDto GradeBookitemDetail { get; set; }

    // Fk EducationalQualityAssuranceLearningObjective
    public int EqaLearningObjectiveId { get; set; }
    public GetEducationalQualityAssuranceLearningObjectiveDto EqaLearningObjective { get; set; }
}
