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
        var graduationCampuses = await _dbModel
        .Include(gc => gc.Campus)
        .ToListAsync();
        return _mapper.Map<ICollection<GetGraduationCampusDto>>(graduationCampuses);
    }

    public async new Task<GraduationCampus?> GetAsync(int id)
    {
        var graduationCampus = await _dbModel
        .Include(gc => gc.Campus)
        .Where(gc => gc.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return graduationCampus;
    }

    public async new Task<GetGraduationCampusDto?> CreateAsync(GraduationCampus newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Campus = _dbContext.Campuses.Find(newItem.CampusId);
            return _mapper.Map<GetGraduationCampusDto>(newItem);
        }
        return null;
    }

    public async new Task<GetGraduationCampusDto?> UpdateAsync(GraduationCampus updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Campus = _dbContext.Campuses.Find(updatedItem.CampusId);
            return _mapper.Map<GetGraduationCampusDto>(updatedItem);
        }
        return null;
    }
}
