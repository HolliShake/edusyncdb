using APPLICATION.Dto.GraduationApplicant;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class GraduationApplicantService:GenericService<GraduationApplicant, GetGraduationApplicantDto>, IGraduationApplicantService
{
    public GraduationApplicantService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
