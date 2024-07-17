namespace DOMAIN.Model;

public class Requirement
{
    public int Id { get; set; }
    public string RequirementName { get; set; }
    public string RequirementDescription { get; set; }
    public bool IsOptional { get; set; }
    public bool IsActive { get; set; }
}