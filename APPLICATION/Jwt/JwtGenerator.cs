using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace APPLICATION.Jwt;

public abstract class JwtGenerator
{
    public static JwtAuthResult GenerateToken(
        IJwtAuthManager ijwAuthManager, 
        string id, 
        string userEmail,
        string role,
        int? academicProgramId,
        int? collegeId,
        bool isFaculty,
        bool isStudent
    )
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Email, userEmail),
            new Claim(ClaimTypes.Role, role),
            // Flags for College Dean
            new Claim("CollegeId", ((collegeId != null) ? collegeId.ToString() : "0")!),
            // Flags for Program Chair
            new Claim("AcademicProgramId", ((academicProgramId != null) ? academicProgramId.ToString() : "0")!),
            //
            new Claim("IsProgramChair", (
                 academicProgramId.ToString() != "0"    &&
                 academicProgramId.ToString() != "null" &&
                !academicProgramId.ToString().IsNullOrEmpty()).ToString()),
            new Claim("IsFaculty", isFaculty.ToString()),
            new Claim("IsStudent", isStudent.ToString()),
            new Claim("IsCollegeDean", (
                 collegeId.ToString() != "0"    &&
                 collegeId.ToString() != "null" &&
                !collegeId.ToString().IsNullOrEmpty()).ToString()),
        };

        return ijwAuthManager.GenerateTokens(userEmail, claims, DateTime.Now);
    }
}