using AutoMapper;
using APPLICATION.Dto.OtherSchool;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class OtherSchoolService:GenericService<OtherSchool, GetOtherSchoolDto>, IOtherSchoolService
{
    public OtherSchoolService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
