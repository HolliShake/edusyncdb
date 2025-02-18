using AutoMapper;
using APPLICATION.Dto.GraduationApplicant;
using APPLICATION.IService.GraduateData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.GraduateData;

public class GraduationApplicantService:GenericService<GraduationApplicant, GetGraduationApplicantDto>, IGraduationApplicantService
{
    public GraduationApplicantService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
