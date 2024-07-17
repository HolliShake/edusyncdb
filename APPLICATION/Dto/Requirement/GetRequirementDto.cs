using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Requirement;
public class GetRequirementDto
{
    public int Id { get; set; }
    public string RequirementName { get; set; }
    public string RequirementDescription { get; set; }
    public bool IsOptional { get; set; }
    public bool IsActive { get; set; }
}
