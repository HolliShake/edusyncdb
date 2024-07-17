using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.Room;
public class RoomDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string RoomName { get; set; }
    [Required]
    public int Capacity { get; set; }
    [Required]
    public bool IsLab { get; set; }
    [Required]
    public bool IsEspecializedLab { get; set; }

    // Fk Building
    [Required]
    public int BuildingId { get; set; }
}
