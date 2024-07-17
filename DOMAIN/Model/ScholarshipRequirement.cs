namespace DOMAIN.Model;

public class ScholarshipRequirement
{
    public int Id { get; set; }

    // Fk ScholarshipList
    public int ScholarshipListId { get; set; }
    public ScholarshipList ScholarshipList { get; set; }

    // Fk Requirement
    public int RequirementId { get; set; }
    public Requirement Requirement { get; set; }
}