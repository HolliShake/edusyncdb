using APPLICATION.Dto.GraduationCampus;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GraduationCampusService:GenericService<GraduationCampus, GetGraduationCampusDto>, IGraduationCampusService
{
    public GraduationCampusService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetGraduationCampusDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetGraduationCampusDto>>(await _dbModel
            .Include(gc => gc.Campus)
            .ToListAsync());
    }

    public async new Task<GetGraduationCampusDto?> GetAsync(int id)
    {
        return _mapper.Map<GetGraduationCampusDto?>(await _dbModel
            .Include(gc => gc.Campus)
            .Where(gc => gc.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(GraduationCampus newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Campus = await _dbContext.Campuses.FindAsync(newItem.CampusId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GraduationCampus updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Campus = await _dbContext.Campuses.FindAsync(updatedItem.CampusId);
        }
        return result;
    }
}
