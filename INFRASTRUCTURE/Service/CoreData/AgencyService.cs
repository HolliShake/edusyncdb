using AutoMapper;
using APPLICATION.Dto.Agency;
using APPLICATION.IService.CoreData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.CoreData;

public class AgencyService:GenericService<Agency, GetAgencyDto>, IAgencyService
{
    public AgencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}