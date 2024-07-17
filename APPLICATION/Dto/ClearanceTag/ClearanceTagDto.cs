using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPLICATION.Dto.ClearanceTag;
public class ClearanceTagDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    public string Description { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(1 << 16)]
    public string SettlementInstruction { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public bool IsExtensible { get; set; }
    [Required]
    public bool IsOptional { get; set; }
    [Required]
    public bool IsSettled { get; set; }
    [Required]
    public DateTime Deadline { get; set; }
    [Required]
    public DateTime ExtendedDeadline { get; set; }
    [Required]
    public DateTime SettledDate { get; set; }
    [Required]
    public DateTime RemindMeDate { get; set; }

    // Fk ClearanceType
    [Required]
    public int ClearanceTypeId { get; set; }

    // Fk DuWhoTag
    [Required]
    public string DuWhoTagId { get; set; }

    // Fk User
    [Required]
    public string UnclearedUserId { get; set; }

    // Fk User
    [Required]
    public string UserWhoClearedId { get; set; }
}
