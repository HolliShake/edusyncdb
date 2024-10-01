using DOMAIN.Model;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplicant;
public class AdmissionApplicantDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(10)]
    public string? Extension { get; set; }

    [Required]
    [MinLength(25)]
    [MaxLength(255)]
    public string Address { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(11)]
    public string MobileNumber { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    public string Province { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Barangay { get; set; }

    [Required]
    public bool? IsSoloParent { get; set; }

    [Required]
    public bool? IsChildOfSoloParent { get; set; }
    [Required]
    public bool IsOnsite { get; set; }
    [Required]
    public AdmissionApplicantType ApplicationType { get; set; }
    [Required]
    public int AcademicProgramChoiceId1 { get; set; }
    [Required]
    public int AcademicProgramChoiceId2 { get; set; }
    [Required]
    public int? AcademicProgramChoiceId3 { get; set; }
}
