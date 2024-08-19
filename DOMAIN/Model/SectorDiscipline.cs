

using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class SectorDiscipline
{
    public int Id { get; set; }
    public string DisciplineDescription { get; set; }

    // Fk SectorDiscipline
    [ForeignKey("Parent")]
    public int? ParentId { get; set; }
    public SectorDiscipline? Parent { get; set; }

    // Nav
    public ICollection<SectorDiscipline> Children { get; set; }
}