
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentGradeService:GenericService<EnrollmentGrade>, IEnrollmentGradeService
{
    public EnrollmentGradeService(AppDbContext context):base(context)
    {
    }
}
