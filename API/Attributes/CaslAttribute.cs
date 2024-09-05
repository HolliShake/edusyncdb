using System.Net;
using System.Security.Claims;
using System.Text.Json;
using API.Constant;
using APPLICATION.Dto.User;
using APPLICATION.Dto.UserAccess;
using APPLICATION.IService;
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
    private IUserAccessService _userAccessRepo;
    private IJwtAuthManager _jwtAuthManager;

    public CaslAttribute(params string[] accessList)
    {
        _validAccessList = accessList;
        _userAccessRepo = null;
        _jwtAuthManager = null;
    }

    public static string RoleToString(ICollection<UserAccessGroupedBy> accessList)
    {
        var data = "";
        var indx = 0;
        foreach (var item in accessList)
        {
            data += "{";
            data += $"\"id\": {item.AccessGroup.Id}, ";
            data += $"\"accessGroup\": \"{item.AccessGroup.AccessGroupName}\", ";
            data += $"\"accessLists\":";

            data += "[";
            var notUnique = item.UserAccesses.Select(ua => ua.AccessList.Subject).ToList();
            List<string> subjects = [];
            foreach (var acl in notUnique)
            {
                if (!subjects.Contains(acl))
                {
                    subjects.Add(acl);
                }
            }
            var subject_index = 0;
            foreach (var acl in subjects)
            {
                data += "{";
                data += $"\"subject\": \"{acl}\", ";
                data += "\"actions\":";
                data += "[";
                var actions = item.UserAccesses.Where(ua => ua.AccessList.Subject == acl).Select(ua => ua.AccessListAction.Action).ToList();
                foreach (var action in actions)
                {
                    data += $"\"{action}\"";
                    if (actions.IndexOf(action) < actions.Count - 1)
                    {
                        data += ", ";
                    }
                }
                data += "]";
                data += "}";
                subject_index++;
                if (subject_index < subjects.Count)
                {
                    data += ", ";
                }
            }
            data += "]";

            data += "}";
            ++indx;

            if (indx < accessList.Count)
            {
                data += ", ";
            }
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

  
        _userAccessRepo = (IUserAccessService)context.HttpContext.RequestServices.GetService(typeof(IUserAccessService));


        if (_userAccessRepo == null)
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
        
        ICollection<UserAccessGroupedBy> grouped = null;

        try
        {
            var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
            var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
            var userAccess = _userAccessRepo.GetUserAccessByUserIdSync(userId);
            if (userAccess.Count <= 0)
            {
                goto bad;
            }
            grouped = userAccess;
        }
        catch (Exception)
        {
            goto bad;
        }

        if (grouped != null)
        {
            var matches = 0;
            foreach (var item in grouped)
            {
                foreach (var accessGrouped in item.UserAccesses)
                {
                    var key = accessGrouped.AccessList.Subject;
                    var val = accessGrouped.AccessListAction.Action;
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
            }

            return;
        }
        
        bad:;
        context.Result = new UnauthorizedObjectResult("UnAuthorized Access Detected!!!!");
        context.HttpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        context.HttpContext.Response.CompleteAsync();
        return;
    }
}