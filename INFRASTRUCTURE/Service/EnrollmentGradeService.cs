using APPLICATION.Dto.EnrollmentGrade;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class EnrollmentGradeService:GenericService<EnrollmentGrade, GetEnrollmentGradeDto>, IEnrollmentGradeService
{
    public EnrollmentGradeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
