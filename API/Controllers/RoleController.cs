using API.Attributes;
using API.Constant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Casl("SuperAdmin:all")]
public class RoleController : ControllerBase
{
    /// <summary>
    /// Get all roles.
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    public IActionResult GetRoles()
    {
        return Ok(new List<string> {
            Role.User,
            Role.Student,
            Role.Admin,
            Role.SuperAdmin,
        });
    }
}