using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceType;
public class EducationalQualityAssuranceTypeDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string ShortName { get; set; }
    //
    [MaxLength(25)]
    public string EqaLabel1 { get; set; }
    [MaxLength(25)]
    public string EqaLabel2 { get; set; }
    [MaxLength(25)]
    public string EqaLabel3 { get; set; }
    [MaxLength(25)]
    public string EqaLabel4 { get; set; }
}
