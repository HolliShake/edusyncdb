using APPLICATION.Dto.College;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CollegeService:GenericService<College, GetCollegeDto>, ICollegeService
{
    public CollegeService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCollegeDto>> GetCollegesByCampusId(int campusId)
    {
        return _mapper.Map<ICollection<GetCollegeDto>>(await _dbModel.Where(c => c.CampusId == campusId).ToListAsync());
    }
}
