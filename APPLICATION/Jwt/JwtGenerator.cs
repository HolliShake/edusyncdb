using System.Security.Claims;

namespace APPLICATION.Jwt;

public abstract class JwtGenerator
{
    public static JwtAuthResult GenerateToken(
        IJwtAuthManager ijwAuthManager, 
        string id, 
        string userEmail,
        string role,
        // Ids for special designation
        int? collegeDeanCollegeId,
        int? academicProgramChairProgramId,
        int? specializationChairTrackSpecializationId,
        int? schedulerCampusId,
        int? registrarCampusId,
        // Flags
        bool isCollegeDean,
        bool isProgramChair,
        bool isFaculty,
        bool isStudent,
        bool isSpecializationChair,
        bool isScheduler,
        bool isRegistrar
    )
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.Role , role),
            // Flags for College Dean
            new Claim("CollegeId",
                ((collegeDeanCollegeId  !=  null)
                ? collegeDeanCollegeId.ToString() 
                : "0")!),
            // Flags for Program Chair
            new Claim("AcademicProgramId", 
                ((academicProgramChairProgramId  !=  null) 
                ? academicProgramChairProgramId.ToString() 
                : "0")!),
            // Flags for Specialization Chair
            new Claim("TrackSpecializationId", 
                ((specializationChairTrackSpecializationId  !=  null)
                ? specializationChairTrackSpecializationId.ToString()
                : "0")!),
            // Flags for Scheduler
            new Claim("SchedulerCampusId", (schedulerCampusId ?? 0).ToString()),
            // Flags for Registrar
            new Claim("RegistrarCampusId", (registrarCampusId ?? 0).ToString()),
            // Flags for Admin
            new Claim("IsAdmin"       , (role == "SuperAdmin").ToString()),
            new Claim("IsCollegeDean" , isCollegeDean .ToString()),
            new Claim("IsProgramChair", isProgramChair.ToString()),
            new Claim("IsFaculty"     , isFaculty     .ToString()),
            new Claim("IsStudent"     , isStudent     .ToString()),
            new Claim("IsScheduler"   , isScheduler   .ToString()),
            new Claim("IsScheduler"   , isRegistrar   .ToString())
        };

        return ijwAuthManager.GenerateTokens(userEmail, claims, DateTime.Now);
    }
}