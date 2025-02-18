using System.Security.Claims;
using APPLICATION.Dto.Auth;
using AutoMapper;
using APPLICATION.Jwt;
using DOMAIN.Model;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using API.Constant;
using API.Attributes;
using API.Utility;
using APPLICATION.IService.DesignationData;
using APPLICATION.IService.EnrollmentData;
using APPLICATION.IService.FileManagerData;
using APPLICATION.IService.SecurityData;
using Microsoft.EntityFrameworkCore;

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
    private readonly IUserAccessGroupDetailsService _userAccessGroupDetailsService;
    private readonly IAcademicProgramChairService _academicProgramChairService;
    private readonly IScheduleTeacherService _scheduleTeacherServiceService;
    private readonly IEnrollmentService _enrollmentService;
    private readonly ICollegeDeanService _collegeDeanServiceService;
    private readonly ISpecializationChairService _specializationChairService;
    private readonly ICampusSchedulerService _campusSchedulerService;
    private readonly IFileManagerService _fileManagerService;
    
    public AuthController(
        ConfigurationManager           config, 
        IMapper                        mapper, 
        IJwtAuthManager                jwtAuthManager, 
        UserManager<User>              userManager, 
        SignInManager<User>            signInManager, 
        IUserAccessGroupDetailsService userAccessGroupDetailsService,
        IAcademicProgramChairService   academicProgramChairService,
        IScheduleTeacherService        scheduleTeacherService,
        IEnrollmentService             enrollmentService,
        ICollegeDeanService            collegeDeanService,
        ISpecializationChairService    specializationChairService,
        ICampusSchedulerService        campusSchedulerService,
        IFileManagerService            fileManagerService
    )
    {
        _config                        = config;
        _mapper                        = mapper;
        _jwtAuthManager                = jwtAuthManager;
        _userManager                   = userManager;
        _signInManager                 = signInManager;
        _userAccessGroupDetailsService = userAccessGroupDetailsService;
        _academicProgramChairService   = academicProgramChairService;
        _scheduleTeacherServiceService = scheduleTeacherService;
        _enrollmentService             = enrollmentService;
        _collegeDeanServiceService     = collegeDeanService;
        _specializationChairService    = specializationChairService;
        _campusSchedulerService        = campusSchedulerService;
        _fileManagerService            = fileManagerService;
    }
    
    /// <summary>
    /// Login attempt.
    /// </summary>
    /// <returns>AuthData</returns>
    [HttpPost("login")]
    public async Task<ActionResult> LoginAttempt(AuthDto credential)
    {
        var user = await _userManager.Users.Where(user => user.Email == credential.Email).FirstOrDefaultAsync();

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
        var access = await _userAccessGroupDetailsService.GetUserAccessGroupByUserGuid(userData.Id);

        userData.UserAccessGroupDetails = access;

        var token = JwtGenerator.GenerateToken(
            _jwtAuthManager,
            user.Id,
            user.Email,
            user.Role,
            (await _collegeDeanServiceService  .GetCollegeByUserId(userData.Id))?.Id,
            (await _academicProgramChairService.GetAcademicProgramByUserId(userData.Id))?.Id,
            (await _specializationChairService .GetTrackSpecializationByUserId(userData.Id))?.Id,
            (await _campusSchedulerService     .GetScheduleByUserId(userData.Id))?.Id,
            // Flags
            (await _collegeDeanServiceService    .IsCollegeDean(userData.Id)),
            (await _academicProgramChairService  .IsProgramChair(userData.Id)),
            (await _scheduleTeacherServiceService.IsTeacher(userData.Id)),
            (await _enrollmentService            .IsStudent(userData.Id)),
            (await _specializationChairService   .IsSpecializationChair(userData.Id)),
            (await _campusSchedulerService       .IsScheduler(userData.Id))
        );

        var profiles = await _fileManagerService.GetFileByScopeAndReferenceId("User:Profile", user.Id.ToString());


        userData.IsGoogle = false;
        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        userData.ProfileImage = profiles.FirstOrDefault()?.ScopePath;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupDetails = [];
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
        Console.WriteLine(_config["Auth:Google:ClientId"]);

        var settings = new GoogleJsonWebSignature.ValidationSettings
        {
            // Change this to your google client ID
            Audience = new List<string>() { _config["Auth:Google:ClientId"] },

            ForceGoogleCertRefresh = true,
            // Allow a small positive tolerance for issued-at and expiration times
            IssuedAtClockTolerance = TimeSpan.FromSeconds(50), // Positive tolerance
            ExpirationTimeClockTolerance = TimeSpan.FromSeconds(-50),
        };

        var payload  = (GoogleJsonWebSignature.ValidateAsync(google.GToken, settings).Result);

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
        var user = await _userManager.Users.Where(user => user.Email == payload.Email).FirstOrDefaultAsync();

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
        
        final:;
        /*
        if (!user.EmailConfirmed)
        {
            return Unauthorized("Email is not authorized");
        }
        */

        var userData = _mapper.Map<AuthDataDto>(user);
        var access = await _userAccessGroupDetailsService.GetUserAccessGroupByUserGuid(userData.Id);

        userData.UserAccessGroupDetails = access;

        var token = JwtGenerator.GenerateToken(
            _jwtAuthManager,
            user.Id,
            user.Email,
            user.Role,
            (await _collegeDeanServiceService  .GetCollegeByUserId(userData.Id))?.Id,
            (await _academicProgramChairService.GetAcademicProgramByUserId(userData.Id))?.Id,
            (await _specializationChairService .GetTrackSpecializationByUserId(userData.Id))?.Id,
            (await _campusSchedulerService     .GetScheduleByUserId(userData.Id))?.Id,
            // Flags
            (await _collegeDeanServiceService    .IsCollegeDean(userData.Id)),
            (await _academicProgramChairService  .IsProgramChair(userData.Id)),
            (await _scheduleTeacherServiceService.IsTeacher(userData.Id)),
            (await _enrollmentService            .IsStudent(userData.Id)),
            (await _specializationChairService   .IsSpecializationChair(userData.Id)),
            (await _campusSchedulerService       .IsScheduler(userData.Id))
        );

        var profiles = await _fileManagerService.GetFileByScopeAndReferenceId("User:Profile", user.Id.ToString());

        userData.IsGoogle = true;
        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        userData.ProfileImage = profiles.FirstOrDefault()?.ScopePath;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupDetails = [];
        userData.AccessListString = AesEncrypt.EncryptString(accessListString);

        return Ok(userData);
    }

    /// <summary>
    /// Generate admin account.
    /// </summary>
    /// <param name="secret"></param>
    /// <returns></returns>
    [HttpPost("generate/{secret}")]
    public async Task<ActionResult> GenerateAdmin(string secret)
    {
        var old  = await _userManager.FindByEmailAsync(_config["Admin:Email"]);
        var user = new User
        {
            Email     = _config["Admin:Email"    ],
            UserName  = _config["Admin:Username" ],
            FirstName = _config["Admin:Firstname"],
            LastName  = _config["Admin:Lastname" ],
            EmailConfirmed = true,
            Role = Role.SuperAdmin
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
            userData.UserAccessGroupDetails = await _userAccessGroupDetailsService.GetUserAccessGroupByUserGuid(userData.Id); ;

        var token = JwtGenerator.GenerateToken(
           _jwtAuthManager,
            user.Id,
            user.Email,
            user.Role,
            (await _collegeDeanServiceService  .GetCollegeByUserId(userData.Id))?.Id,
            (await _academicProgramChairService.GetAcademicProgramByUserId(userData.Id))?.Id,
            (await _specializationChairService .GetTrackSpecializationByUserId(userData.Id))?.Id,
            (await _campusSchedulerService     .GetScheduleByUserId(userData.Id))?.Id,
            // Flags
            (await _collegeDeanServiceService    .IsCollegeDean(userData.Id)),
            (await _academicProgramChairService  .IsProgramChair(userData.Id)),
            (await _scheduleTeacherServiceService.IsTeacher(userData.Id)),
            (await _enrollmentService            .IsStudent(userData.Id)),
            (await _specializationChairService   .IsSpecializationChair(userData.Id)),
            (await _campusSchedulerService       .IsScheduler(userData.Id))
        );

        var profiles = await _fileManagerService.GetFileByScopeAndReferenceId("User:Profile", user.Id.ToString());

        userData.AccessToken = /**/
            token.AccessToken;
        userData.RefreshToken = /**/
            token.RefreshToken.TokenString;

        userData.ProfileImage = profiles.FirstOrDefault()?.ScopePath;

        var accessListString = userData.AccessListString;
        userData.UserAccessGroupDetails = [];
        userData.AccessListString = AesEncrypt.EncryptString(accessListString);

        return Ok(userData);
    }
}