using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.Model;

public class UserAccess
{
    public int Id { get; set; }

    // Fk User
    public string UserId { get; set; }
    public User User { get; set; }

    // Fk AccessList
    public int AccessListId { get; set; }
    public AccessList AccessList { get; set; }

    // FK AccessListAction
    public int AccessListActionId { get; set; }
    public AccessListAction AccessListAction { get; set; }
}