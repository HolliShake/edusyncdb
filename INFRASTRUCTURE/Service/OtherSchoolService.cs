using APPLICATION.Dto.OtherSchool;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class OtherSchoolService:GenericService<OtherSchool, GetOtherSchoolDto>, IOtherSchoolService
{
    public OtherSchoolService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
