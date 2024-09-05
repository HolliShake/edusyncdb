using APPLICATION.Dto.PortfolioProvider;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class PortfolioProviderService:GenericService<PortfolioProvider, GetPortfolioProviderDto>, IPortfolioProviderService
{
    public PortfolioProviderService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetPortfolioProviderDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetPortfolioProviderDto>>(await _dbModel
            .Include(pp => pp.SectorDiscipline)
            .ToListAsync());
    }

    public async new Task<GetPortfolioProviderDto?> GetAsync(int id)
    {
        return _mapper.Map<GetPortfolioProviderDto?>(await _dbModel
            .Include(pp => pp.SectorDiscipline)
            .Where(pp => pp.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(PortfolioProvider newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(newItem.SectorDisciplineId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(PortfolioProvider updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.SectorDiscipline = await _dbContext.SectorDisciplines.FindAsync(updatedItem.SectorDisciplineId);
        }
        return result;
    }
}
