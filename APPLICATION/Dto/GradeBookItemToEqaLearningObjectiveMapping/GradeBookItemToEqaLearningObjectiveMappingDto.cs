using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GradeBookItemToEqaLearningObjectiveMapping;
public class GradeBookItemToEqaLearningObjectiveMappingDto
{

    // Fk GradeBookItemDetail
    public int GradeBookItemDetailId { get; set; }

    // Fk EducationalQualityAssuranceLearningObjective
    public int EqaLearningObjectiveId { get; set; }
}
