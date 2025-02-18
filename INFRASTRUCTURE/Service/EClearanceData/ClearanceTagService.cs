using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.ClearanceTag;
using APPLICATION.Dto.User;
using APPLICATION.IService.EClearanceData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.EClearanceData;

public class ClearanceTagService:GenericService<ClearanceTag, GetClearanceTagDto>, IClearanceTagService
{
    public ClearanceTagService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<GetClearanceTagDto?> UpdateAsync(ClearanceTag updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            if (updatedItem.DuWhoTagId != null)
            {

                updatedItem.ClearanceType = _dbContext.ClearanceTypes.Find(updatedItem.ClearanceTypeId);
                updatedItem.DuWhoTag = _dbContext.Users.Find(updatedItem.DuWhoTagId);
                updatedItem.UserWhoCleared = _dbContext.Users.Find(updatedItem.UserWhoClearedId);
            }
            return _mapper.Map<GetClearanceTagDto>(updatedItem);
        }
        return null;
    }
    public async Task<ICollection<GetClearanceTagDto>> GetClearanceTagsByClearanceTypeId(int clearanceTypeId)
    {
        var clearanceTags = await _dbModel
        .Where(ct => ct.ClearanceTypeId == clearanceTypeId)
        .ToListAsync();
        return _mapper.Map<ICollection<GetClearanceTagDto>>(clearanceTags);
    }

    public async Task<object?> ChangedSettled(string userId, int clearancetagId, bool isSettled)
    {
        var currentState = _dbModel.Find(clearancetagId);
        if (currentState == null)
        {
            return null;
        }
        currentState.IsSettled = isSettled;
        if (isSettled)
        {
            currentState.UserWhoClearedId = userId;
            currentState.SettledDate = DateTime.Now;
        }
        return await UpdateAsync(currentState);
    }
    public async Task<object> GetEClearanceTagByStudentUserId(string userId)
    {
        var items = await _dbModel
            .Include(ct => ct.ClearanceType)
            .Include(ct => ct.DuWhoTag)
            .Where(ct => ct.UnclearedUserId == userId)
            .ToListAsync();
        return (new
        {
            Cleared = items
                .Where(tag => tag.IsSettled)
                .Select(tag => new
                {
                    Id = tag.Id,
                    ClearanceType = tag.ClearanceType,
                    Description = tag.Description,
                    TaggedBy = _mapper.Map<GetUserOnlyDto?>(tag.DuWhoTag),
                    TaggedDate = tag.DateCreated,
                    IsSettled = tag.IsSettled,
                    ClearedAndSettledBy = _mapper.Map<GetUserOnlyDto?>(tag.UserWhoCleared),
                    ClearedAndSettledDate = tag.SettledDate
                }),
           UnCleared = items
                .Where(tag => !tag.IsSettled)
                .Select(tag => new
                {
                    Id = tag.Id,
                    ClearanceType = tag.ClearanceType,
                    TaggedBy = _mapper.Map<GetUserOnlyDto?>(tag.DuWhoTag),
                    TaggedDate = tag.DateCreated,
                    IsSettled = tag.IsSettled,
                    ClearedAndSettledBy = _mapper.Map<GetUserOnlyDto?>(tag.UserWhoCleared),
                    ClearedAndSettledDate = tag.SettledDate
                })
        });
    }
}
