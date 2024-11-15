using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class ClearanceTag
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public string SettlementInstruction { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Amount { get; set; }
    public bool IsExtensible { get; set; }
    public bool IsOptional { get; set; }
    public bool IsSettled { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime ExtendedDeadline { get; set; }
    public DateTime? SettledDate { get; set; }
    public DateTime RemindMeDate { get; set; }

    // Fk ClearanceType
    public int ClearanceTypeId { get; set; }
    public ClearanceType ClearanceType { get; set; }

    // Fk DuWhoTag
    public string DuWhoTagId { get; set; }
    public User DuWhoTag { get; set; }

    // Fk User
    public string UnclearedUserId { get; set; }
    public User UnclearedUser { get; set; }

    // Fk User
    public string? UserWhoClearedId { get; set; }
    public User UserWhoCleared { get; set; }
}