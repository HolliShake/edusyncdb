using APPLICATION.Dto.Agency;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace INFRASTRUCTURE.Service;
public class AgencyService:GenericService<Agency, GetAgencyDto>, IAgencyService
{
    public AgencyService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    static bool CanAccess(List<Access> accessList, Agency agency)
    {
        return accessList
            .Where(al => al.action
            .Equals("read"))
            .Any(al => al.subject.Equals(agency.AgencyName));
    }

    public async Task<ICollection<GetAgencyDto>> GetMyAccessibleAgencies(string accessListJSON)
    {
        var json = JsonSerializer.Deserialize<List<Access>>(accessListJSON);

        return _mapper.Map<ICollection<GetAgencyDto>>((await _dbModel.ToListAsync()).Select(agency => agency).Where(agency => CanAccess(json, agency)));
    }
}


class Access
{
    public string subject { get; set; }
    public string action { get; set; }
}