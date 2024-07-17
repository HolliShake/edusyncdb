using APPLICATION.Dto.ClearanceType;
using APPLICATION.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dto.ClearanceTag;
public class GetClearanceTagDto
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public string Description { get; set; }
    public string SettlementInstruction { get; set; }
    public decimal Amount { get; set; }
    public bool IsExtensible { get; set; }
    public bool IsOptional { get; set; }
    public bool IsSettled { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime ExtendedDeadline { get; set; }
    public DateTime SettledDate { get; set; }
    public DateTime RemindMeDate { get; set; }

    // Fk ClearanceType
    public int ClearanceTypeId { get; set; }
    public GetClearanceTypeDto ClearanceType { get; set; }

    // Fk DuWhoTag
    public string DuWhoTagId { get; set; }
    public GetUserOnlyDto DuWhoTag { get; set; }

    // Fk User
    public string UnclearedUserId { get; set; }
    public GetUserOnlyDto UnclearedUser { get; set; }

    // Fk User
    public string UserWhoClearedId { get; set; }
    public GetUserOnlyDto UserWhoCleared { get; set; }
}
