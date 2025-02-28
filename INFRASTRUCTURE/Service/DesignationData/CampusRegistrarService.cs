using APPLICATION.Dto.AcademicProgram;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusRegistrar;
using APPLICATION.IService.DesignationData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service.DesignationData;
public class CampusRegistrarService : GenericService<CampusRegistrar, GetCampusRegistrarDto>, ICampusRegistrarService
{
    public CampusRegistrarService(AppDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<bool> IsCampusRegistrar(string userId)
    {
        return await _dbModel.Where(cr => cr.UserId == userId).AnyAsync();
    }

    public async Task<GetCampusDto> GetCampusByUserId(string userId)
    {
        return await _dbModel
            .Include(cr => cr.Campus)
            .Where(cr => cr.UserId == userId)
            .Select(cr => _mapper.Map<GetCampusDto>(cr.Campus))
            .SingleOrDefaultAsync();
    }
}
