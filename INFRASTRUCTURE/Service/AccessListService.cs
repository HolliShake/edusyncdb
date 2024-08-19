
using APPLICATION.Dto.AccessList;
using APPLICATION.Dto.AccessListAction;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INFRASTRUCTURE.Service;
public class AccessListService:GenericService<AccessList, GetAccessListDto>, IAccessListService
{
    public AccessListService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public new async Task<ICollection<GetAccessListDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetAccessListDto>>(await _dbModel.Include(al => al.AccessListActions).ToListAsync());
    }
    
    public new async Task<AccessList?> GetAsync(int id)
    {
        return _mapper.Map<AccessList?>(await _dbModel
                .Include(al => al.AccessListActions)
                .Include(al => al.Children)
                .ThenInclude(al => al.AccessListActions)
                .Include(al => al.Children)
                .Where(al => al.Id == id)
                .FirstOrDefaultAsync());
    }

    public async Task<ICollection<GetAccessListDto>> GetGroups()
    {
        return _mapper.Map<ICollection<GetAccessListDto>>(await _dbModel
            .Include(al => al.AccessListActions)
            .Where(al => al.IsGroup)
            .ToListAsync());
    }

    public async Task<List<GetAccessListDto>> GetParentAccess()
    {
        return _mapper.Map<List<GetAccessListDto>>(await _dbModel
            .Include(al => al.AccessListActions)
            .Include(al => al.Children)
                .ThenInclude(al => al.AccessListActions)
                .Include(al => al.Children)
                .ThenInclude(al => al.Children)
                .ThenInclude(al => al.AccessListActions)
            .Where(al => al.Type == AccessListType.GLOBAL)
            .Where(al => al.ParentId == null)
            .ToListAsync());
    }

    public async Task<bool> ImportAgencies()
    {
        var agencies = await _dbContext.Agencies.ToListAsync();
        var agencyData = await _dbModel.Where(al => al.Subject.ToLower().Trim().Equals("agency")).FirstOrDefaultAsync();

        if (agencyData == null)
        {
            return false;
        }

        foreach (var agency in agencies)
        {
            try
            {
                var data = (await _dbModel
                        .Where(al => al.ReferenceId == agency.Id)
                        .Where(al => al.Type == AccessListType.AGENCY).FirstOrDefaultAsync());
                if (data == null)
                {
                    // Create
                    await this.CreateAsync(new AccessList { 
                        Subject = agency.AgencyName,
                        IsGroup = false,
                        ReferenceId = agency.Id,
                        Type = AccessListType.AGENCY,
                        ParentId = agencyData.Id
                    });
                }
                else
                {
                    // Update
                    await this.UpdateSync(new AccessList
                    {
                        Id = data.Id,
                        Subject = agency.AgencyName,
                        IsGroup = data.IsGroup,
                        ReferenceId = data.Id,
                        Type = AccessListType.AGENCY,
                        ParentId = agencyData.Id
                    });
                }
            }
            catch (Exception)
            {
            }
        }

        return true;
    }
}