using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Agency;
public class AgencyDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(75)]
    public string AgencyName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(10)]
    public string ShortName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(8)]
    public string Code { get; set; }

    [Required]
    [MinLength(25)]
    [MaxLength(255)]
    public string AgencyAddress { get; set;}
}
