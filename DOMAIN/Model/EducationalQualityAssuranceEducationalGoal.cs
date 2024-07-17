namespace DOMAIN.Model;

public class EducationalQualityAssuranceEducationalGoal
{
    public int Id { get; set; }
    public string EqaGoal { get; set; }
    // Fk 
    public int EqaTypeId { get; set; }
    public EducationalQualityAssuranceType EqaType { get; set; }
}