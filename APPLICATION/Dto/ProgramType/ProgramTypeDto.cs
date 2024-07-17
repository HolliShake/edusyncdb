using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ProgramType;

public class ProgramTypeDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(75)]
    public string ProgramTypeName { get; set; }
}
