namespace APPLICATION.Dto.GradeBookScore;

public class GiveGradeBookScoreGroupDto
{
    public int GradeBookItemDetailsId { get; set; }
    public GradeBookStudentIdScorePair[] GradeBookStudentIdScorePairs { get; set; }
}