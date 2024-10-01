using APPLICATION.Dto.CurriculumDetail;
using APPLICATION.Dto.Cycle;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.GeneratedSections;
public class GetGeneratedSectionsDto
{
    public int Id { get; set; }
    public string SectionName { get; set; }
    public string SectionCode { get; set; }
    public int CycleId { get; set; }
    public GetCycleDto Cycle { get; set; }
    public int CurriculumDetailId { get; set; }
    public GetCurriculumDetailDto CurriculumDetail { get; set; }
}
