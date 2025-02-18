using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService.SecurityData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.SecurityData;

public class UserCampusDetailsService:GenericService<UserCampusDetails, GetUserCampusDetailsDto>, IUserCampusDetailsService
{
    public UserCampusDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCampusDto>> GetAllCampusByUserId(string userId)
    {
        var campus = await _dbModel
        .Include(ucd => ucd.Campus)
            .ThenInclude(c => c.Agency)
        .Where(ucd => ucd.UserId == userId)
        .Select(ucd => ucd.Campus)
        .ToListAsync();
        return _mapper.Map<ICollection<GetCampusDto>>(campus);
    }
}
