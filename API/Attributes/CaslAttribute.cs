using System.Net;
using System.Security.Claims;
using API.Constant;
using APPLICATION.Dto.UserAccessGroupDetails;
using APPLICATION.IService.SecurityData;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Attributes;

public class Access
{
    public string subject { get; set; }
    public string action { get; set; }
}

public class CaslAttribute:Attribute, IAuthorizationFilter
{
    private readonly string[] _validAccessList;
    private IJwtAuthManager _jwtAuthManager;
    private IUserAccessGroupDetailsService _userAccessGroupDetailsRepo;

    public CaslAttribute(params string[] accessList)
    {
        _validAccessList = accessList;
        _jwtAuthManager = null;
        _userAccessGroupDetailsRepo = null;
    }

    public static string RoleToString(ICollection<GetUserAccessGroupDetailsDto> userAccessGroupDetails)
    {
        var data = "";
        List<string> uniqueAccessGroup = [];
        foreach (var item in userAccessGroupDetails)
        {
            var name = item.AccessGroupAction.AccessGroup.AccessGroupName;
            if (!uniqueAccessGroup.Contains(name))
            {
                uniqueAccessGroup.Add(name);
            }
        }
        var index_i = 0;
        foreach (var name in uniqueAccessGroup)
        {
            data += "{";
            data += $"\"accessGroup\": \"{name}\", ";
            data += "\"actions\":";
            data += "[";
            
            var access = userAccessGroupDetails.Where(uagd => uagd.AccessGroupAction.AccessGroup.AccessGroupName == name).Select(uagd => uagd.AccessGroupAction.Action).ToList();
            var index_j = 0;
            foreach (var item in access)
            {
                data += $"\"{item}\"";
                if (index_j < access.Count - 1)
                {
                    data += ", ";
                }
                ++index_j;
            }
            data += "]";
            data += "}";
            if (index_i < uniqueAccessGroup.Count - 1)
            {
                data += ", ";
            }
            ++index_i;
        }
        return "[" + data + "]";
    }
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        return;
        if (_validAccessList.Length <= 0)
        {
            return;
        }

        var accessToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(accessToken))
        {
            goto bad;
        }

  
        _userAccessGroupDetailsRepo = (IUserAccessGroupDetailsService) context.HttpContext.RequestServices.GetService(typeof(IUserAccessGroupDetailsService));


        if (_userAccessGroupDetailsRepo == null)
        {
            goto bad;
        }

        _jwtAuthManager = (IJwtAuthManager) context.HttpContext.RequestServices.GetService(typeof(IJwtAuthManager));

        if (_jwtAuthManager == null)
        {
            goto bad;
        }

        accessToken = accessToken.Trim();
        if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(accessToken))
        {
            goto bad;
        }
        
        ICollection<GetUserAccessGroupDetailsDto> uagd = null;

        try
        {
            var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
            var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
            var userAccess = _userAccessGroupDetailsRepo.GetUserAccessGroupByUserGuidSync(userId);
            if (userAccess.Count <= 0)
            {
                goto bad;
            }
            uagd = userAccess;
        }
        catch (Exception)
        {
            goto bad;
        }

        if (uagd != null)
        {
            var matches = 0;
            foreach (var item in uagd)
            {
                var key = item.AccessGroupAction.AccessGroup.AccessGroupName;
                var val = item.AccessGroupAction.Action;
                var access = $"{key}:{val}";

                if (access.Equals($"{Role.SuperAdmin}:all"))
                {
                    return;
                }

                if (_validAccessList.Contains(access))
                {
                    ++matches;
                    break;
                }
            }

            if (matches > 0)
            {
                return;
            }
        }
        
        bad:;
        context.Result = new UnauthorizedObjectResult("UnAuthorized Access Detected!!!!");
        context.HttpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        context.HttpContext.Response.CompleteAsync();
        return;
    }
}