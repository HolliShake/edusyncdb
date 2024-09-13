using APPLICATION.Dto.Campus;
using APPLICATION.Dto.UserCampusDetails;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class UserCampusDetailsService:GenericService<UserCampusDetails, GetUserCampusDetailsDto>, IUserCampusDetailsService
{
    public UserCampusDetailsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCampusDto>> GetAllCampusByUserId(string userId)
    {
        return _mapper.Map<ICollection<GetCampusDto>>(await _dbModel
            .Include(ucd => ucd.Campus)
                .ThenInclude(c => c.Agency)
            .Where(ucd => ucd.UserId == userId)
            .Select(ucd => ucd.Campus)
            .ToListAsync());
    }
}
