using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ClearanceType;
public class ClearanceTypeDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string Type { get; set; }
}
