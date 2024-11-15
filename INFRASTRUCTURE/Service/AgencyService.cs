using APPLICATION.Dto.Agency;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AgencyService:GenericService<Agency, GetAgencyDto>, IAgencyService
{
    public AgencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}