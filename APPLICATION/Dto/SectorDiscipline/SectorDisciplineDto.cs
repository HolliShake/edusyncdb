using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.SectorDiscipline;
public class SectorDisciplineDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string DisciplineDescription { get; set; }

    // Fk SectorDiscipline
    [Required]
    public int? ParentId { get; set; }
}
