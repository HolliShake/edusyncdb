using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplicant;
public class AdmissionApplicantDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string Firstname { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string? Middlename { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Lastname { get; set; }
    [Required]
    [MinLength(25)]
    [MaxLength(255)]
    public string Address { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(11)]
    public string MobileNumber { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(50)]
    public string Email { get; set; }
}
