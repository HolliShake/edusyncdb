using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.Dto.AdmissionSchedule;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.AdmissionApplication;
public class AdmissionApplicationDto
{

    public string ApplicationReferenceNumber 
    {
        get 
        {
            var hash = Util.Hash32($"{this.AdmissionScheduleId}{this.AdmissionApplicantId}{this.SubmissionDate.Hour}:{this.SubmissionDate.Minute}");
            return (hash + $"-{this.SubmissionDate.Year}");
        }
    } // Generated code

    [MaxLength(255)]
    public string? Notes { get; set; }
    [MaxLength(255)]
    public string OverAllStatus { get; set; }
    public DateTime SubmissionDate { get; set; } = DateTime.Now;
    // Fk AdmissionSchedule
    [Required]
    public int AdmissionScheduleId { get; set; }
    // Fk AddmisionApplicant
    [Required]
    public int AdmissionApplicantId { get; set; }
}


internal class Util
{
    public static string Hash32(string str)
    {
        if (str == null)
        {
            return "0";
        }

        if (str.Length == 0)
        {
            return "0";
        }

        var hashc = 0L; // supports 64? (experimental)

        for (int i = 0; i < str.Length; i++)
        {
            hashc = ((hashc << 5) - hashc) + str[i];
            hashc |= 0L;
        }

        if (hashc < 0)
        {
            hashc *= (-1);
        }

        return $"{hashc}";
    }
}
