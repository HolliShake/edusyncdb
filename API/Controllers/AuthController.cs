using System.Security.Claims;
using APPLICATION.Dto.Auth;
using AutoMapper;
using APPLICATION.Jwt;
using DOMAIN.Model;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Dto.UserAccess;
using API.Constant;
using APPLICATION.IService;
using API.Attributes;
using API.utils;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly ConfigurationManager _config;
    private readonly IMapper _mapper;
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserAccessService _userAccessService;
    
    public AuthController(ConfigurationManager config, IMapper mapper, IJwtAuthManager jwtAuthManager, UserManager<User> userManager, SignInManager<User> signInManager, IUserAccessService userAccessService)
    {
        _config = config;
        _mapper = mapper;
        _jwtAuthManager = jwtAuthManager;
        _userManager = userManager;
        _signInManager = signInManager;
        _userAccessService = userAccessService;
    }
    
    /// <summary>
    /// Login attempt.
    /// </summary>
    /// <returns>AuthData</returns>
    [HttpPost("login")]
    public async Task<ActionResult> LoginAttempt(AuthDto credential)
    {
        var user = await _userManager.FindByEmailAsync(credential.Email);

        if (user == null)
        {
            goto Bad;
        }

        var attempt = await _signInManager.CheckPasswordSignInAsync(user, credential.Password, false);

        if (attempt.Succeeded)
        {
            goto Ok;
        }

        Bad:;
        // Set as alternative to Not Found to prevent brute forcing...
        return BadRequest("Invalid username or password");

    Ok:;
        // If allow email verification
        // if (!user.EmailConfirmed)
        // {
        // return Unauthorized("Email is not authorized");
        // }

        var userData = _mapper.Map<AuthDataDto>(user);
        var access = await _userAccessService.GetUserAccessByUserId(userData.Id);

        userData.UserAccessGroupedBy = access;

        var token = JwtGenerator.GenerateToken(_jwtAuthManager, user.Id, user.Email, user.Role, "" /*userData.AccessListString*/);
      
        userData.IsGoogle = false;
        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupedBy = [];
        userData.AccessListString = AesEncrypt.EncryptString(accessListString);

        return Ok(userData);
    }
    
    /// <summary>
    /// Login attempt via google.
    /// </summary>
    /// <returns>AuthData</returns>
    [HttpPost("google-signin")]
    public async Task<ActionResult> GoogleLogin(GoogleDto google)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            // Change this to your google client ID
            Audience = new List<string>() { _config["Auth:Google:ClientId"] }
        };

        var payload  = GoogleJsonWebSignature.ValidateAsync(google.GToken, settings).Result;

        if (payload == null)
        {
            goto error;
        }

        if (payload.Email != null)
        {
            goto ok;
        }
        
        error:;
        return BadRequest("Invalid google signin!");
        
        ok:;
        var user = await _userManager.FindByEmailAsync(payload.Email);

        if (user != null)
        {
            goto final;
        }
        /****** Create new user *****/
        user = new User
        {
            Email = payload.Email,
            UserName = payload.Email,
            FirstName = payload.GivenName,
            LastName = payload.FamilyName,
            EmailConfirmed = payload.EmailVerified,
            Role = Role.User
        };

        var result = await _userManager.CreateAsync(user, payload.Email);

        if (!result.Succeeded)
        {
            goto error;
        }
        else
        {
            try
            {
                // Auth := 1
                // all 1
                // read 2
                // create 3
                // update 4
                // delete 5
                await _userAccessService.CreateUserAccess(user.Id, 1, 1);
                await _userAccessService.CreateUserAccess(user.Id, 1, 2);
                await _userAccessService.CreateUserAccess(user.Id, 1, 3);
                await _userAccessService.CreateUserAccess(user.Id, 1, 4);
                await _userAccessService.CreateUserAccess(user.Id, 1, 5);
                // User := 2
                // all 6
                // read 7
                // create 8
                // update 9
                // delete 10
                await _userAccessService.CreateUserAccess(user.Id, 2, 6);
                await _userAccessService.CreateUserAccess(user.Id, 2, 6);
                await _userAccessService.CreateUserAccess(user.Id, 2, 6);
                await _userAccessService.CreateUserAccess(user.Id, 2, 6);
                await _userAccessService.CreateUserAccess(user.Id, 2, 6);
            }
            catch (Exception)
            {
            }
        }
        
        final:;
        /*
        if (!user.EmailConfirmed)
        {
            return Unauthorized("Email is not authorized");
        }
        */

        var userData = _mapper.Map<AuthDataDto>(user);
        var access = await _userAccessService.GetUserAccessByUserId(userData.Id);

        userData.UserAccessGroupedBy = access;

        var token = JwtGenerator.GenerateToken(_jwtAuthManager, user.Id, user.Email, user.Role, "" /*userData.AccessListString*/);
        
        userData.IsGoogle = true;
        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupedBy = [];
        userData.AccessListString = AesEncrypt.EncryptString(accessListString);

        return Ok(userData);
    }
    
    /// <summary>
    /// Register attempt.
    /// </summary>
    /// <returns>Null|Errors</returns>
    /*
    [HttpPost("register")]
    public async Task<ActionResult> Register(AuthRegisterDto registrationForm)
    {
        var result = await _userManager.CreateAsync(_mapper.Map<User>(registrationForm), registrationForm.Password);

        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest(result.Errors);
    }
    */

    [HttpPost("generate/{secret}")]
    public async Task<ActionResult> GenerateAdmin(string secret)
    {
        var old = await _userManager.FindByEmailAsync(_config["Admin:Email"]);
        var user = new User
        {
            Email = _config["Admin:Email"],
            UserName = _config["Admin:Username"],
            FirstName = _config["Admin:Firstname"],
            LastName = _config["Admin:Lastname"],
            EmailConfirmed = true,
            Role = Role.SuperAdmin
            /*
            Role = "[" +
                   "{ \"subject\": \"Auth\" , \"action\": \"read\"   }," +
                   "{ \"subject\": \"Admin\", \"action\": \"all\"    }," +
                   "{ \"subject\": \"Admin\", \"action\": \"read\"   }," +
                   "{ \"subject\": \"Admin\", \"action\": \"create\" }," +
                   "{ \"subject\": \"Admin\", \"action\": \"update\" }," +
                   "{ \"subject\": \"Admin\", \"action\": \"delete\" }"  +
                   "]"
            */
        };
        
        if (!secret.SequenceEqual(_config["Admin:Secret"]))
        {
            goto bad;
        }

        if (old != null)
        {
            // Already exists!
            goto exists;
        }

        // Create
        var result = await _userManager.CreateAsync(user, _config["Admin:Password"]);

        if (result.Succeeded)
        {
            goto ok;
        }

        goto bad;
        
        exists:;
        return Unauthorized();
        
        bad:;
        return BadRequest("Failed to create admin user.");

    ok:;
        var actualData = old ?? user;
        try
        {
            // Auth := 1
            // all 1
            // read 2
            // create 3
            // update 4
            // delete 5
            await _userAccessService.CreateUserAccess(actualData.Id, 1, 1);
            await _userAccessService.CreateUserAccess(actualData.Id, 1, 2);
            await _userAccessService.CreateUserAccess(actualData.Id, 1, 3);
            await _userAccessService.CreateUserAccess(actualData.Id, 1, 4);
            await _userAccessService.CreateUserAccess(actualData.Id, 1, 5);
            // SuperAdmin := 5
            //  all   11
            //  read  12
            // create 13
            // update 14
            // delete 15
            await _userAccessService.CreateUserAccess(actualData.Id, 5, 21);
            await _userAccessService.CreateUserAccess(actualData.Id, 5, 22);
            await _userAccessService.CreateUserAccess(actualData.Id, 5, 23);
            await _userAccessService.CreateUserAccess(actualData.Id, 5, 24);
            await _userAccessService.CreateUserAccess(actualData.Id, 5, 25);
        } catch (Exception)
        {
        }
        return Ok(actualData);
    }
    
    /// <summary>
    /// ReAuthenticate every page refresh (must use authentication context in UI).
    /// </summary>
    /// <returns>AuthData|Errors</returns>
    [HttpGet("session")]
    [Casl("Auth:all")]
    public async Task<ActionResult> Session()
    {
        var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);

        if (accessToken.Length <= 0)
        {
            goto bad;
        }
        
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(type => type.Type == ClaimTypes.NameIdentifier)?.Value;
        
        if (userId == null)
        {
            goto bad;
        }

        var user = await _userManager.FindByIdAsync(userId);

        if (user != null)
        {
            goto ok;
        }
        
        bad:;
        return Unauthorized();
        
        ok:;
        var userData = _mapper.Map<AuthDataDto>(user);
        var access = await _userAccessService.GetUserAccessByUserId(userData.Id);

        userData.UserAccessGroupedBy = access;

        var token = JwtGenerator.GenerateToken(_jwtAuthManager, userData.Id, userData.Email, userData.Role, "" /*userData.AccessListString*/);
        
        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupedBy = [];
        userData.AccessListString = accessListString;

        return Ok(userData);
    }
}