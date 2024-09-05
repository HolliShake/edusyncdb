using APPLICATION.Dto.Agency;
using APPLICATION.Dto.UserAccess;
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

    static bool CanAccess(ICollection<UserAccessGroupedBy> accessGroup, Agency agency)
    {
        return accessGroup
            .Where(al => al.UserAccesses.Where(ua => ua.AccessList.Subject.Equals(agency.AgencyName)).Any())
            .Any(al => al.UserAccesses.Where(ua => ua.AccessListAction.Action.Equals("read")).Any());
    }

    static bool CanAccessCampus(ICollection<UserAccessGroupedBy> accessGroup, Campus campus)
    {
        return accessGroup
            .Where(al => al.UserAccesses.Where(ua => ua.AccessList.Subject.Equals(campus.CampusName)).Any())
            .Any(al => al.UserAccesses.Where(ua => ua.AccessListAction.Action.Equals("read")).Any());
    }

    public async Task<ICollection<GetAgencyDto>> GetMyAccessibleAgencies(ICollection<UserAccessGroupedBy> accessGroup)
    {
        return _mapper.Map<ICollection<GetAgencyDto>>((await 
            _dbModel.Include(agency => agency.Campuses).ToListAsync())
                .Where(agency => CanAccess(accessGroup, agency))
                .Select(agency => new Agency { 
                    Id = agency.Id,
                    AgencyName = agency.AgencyName,
                    AgencyAddress = agency.AgencyAddress,
                    Campuses = agency.Campuses.Where(campus => CanAccessCampus(accessGroup, campus)).ToList()
                        .Select(campus => new Campus { 
                            Id = campus.Id,
                            CampusName = campus.CampusName,
                            AgencyId = campus.AgencyId,
                            Address = campus.Address,
                            Latitude = campus.Latitude,
                            Longitude = campus.Longitude
                        }).ToList()
                }));
    }
}


class Access
{
    public string subject { get; set; }
    public string action { get; set; }
}