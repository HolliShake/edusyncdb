using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.EducationalQualityAssuranceType;
public class GetEducationalQualityAssuranceTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    //
    public string EqaLabel1 { get; set; }
    public string EqaLabel2 { get; set; }
    public string EqaLabel3 { get; set; }
    public string EqaLabel4 { get; set; }
}
