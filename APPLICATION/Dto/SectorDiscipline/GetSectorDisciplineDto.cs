using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SectorDiscipline;
public class GetSectorDisciplineDto
{
    public int Id { get; set; }
    public string DisciplineDescription { get; set; }

    // Fk SectorDiscipline
    public int? ParentId { get; set; }
    public GetSectorDisciplineDto? Parent { get; set; }
}
