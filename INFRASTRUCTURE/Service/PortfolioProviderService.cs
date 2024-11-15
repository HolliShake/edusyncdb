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
        var portfolioProviders = await _dbModel
        .Include(pp => pp.SectorDiscipline)
        .ToListAsync();
        return _mapper.Map<ICollection<GetPortfolioProviderDto>>(portfolioProviders);
    }

    public async new Task<PortfolioProvider?> GetAsync(int id)
    {
        var portfolioProvider = await _dbModel
        .Include(pp => pp.SectorDiscipline)
        .Where(pp => pp.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return portfolioProvider;
    }

    public async new Task<GetPortfolioProviderDto?> CreateAsync(PortfolioProvider newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(newItem.SectorDisciplineId);
            return _mapper.Map<GetPortfolioProviderDto>(newItem);
        }
        return null;
    }

    public async new Task<GetPortfolioProviderDto?> UpdateAsync(PortfolioProvider updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.SectorDiscipline = _dbContext.SectorDisciplines.Find(updatedItem.SectorDisciplineId);
            return _mapper.Map<GetPortfolioProviderDto>(updatedItem);
        }
        return null;
    }
}
