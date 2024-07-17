using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Requirement;
public class RequirementDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string RequirementName { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(255)]
    public string RequirementDescription { get; set; }
    [Required]
    public bool IsOptional { get; set; }
    [Required]
    public bool IsActive { get; set; }
}
