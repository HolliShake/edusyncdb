using APPLICATION.Dto.CourseCrediting;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CourseCreditingService:GenericService<CourseCrediting, GetCourseCreditingDto>, ICourseCreditingService
{
    public CourseCreditingService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<GetCourseCreditingDto?> CreateAsync(CourseCrediting newItem)
    {
        newItem.Status = GlobalValidityStatusEnum.PENDING;
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            return _mapper.Map<GetCourseCreditingDto>(newItem);
        }
        return null;
    }

    public async Task<object> ApproveByUserAndId(string userId, int courseCreditingId)
    {
        var model = await _dbModel.Where(cc => cc.Id == courseCreditingId).SingleOrDefaultAsync();
        if (model == null)
        {
            throw new Error404("CourseCrediting not found.");
        }

        model.EvaluatedByUserId = userId;
        model.CreditedDateTime  = DateTime.Now;
        model.Status = GlobalValidityStatusEnum.APPROVED;
        return await UpdateAsync(model);
    }

    public async Task<object> RejectByUserAndId(string userId, int courseCreditingId)
    {
        var model = await _dbModel.Where(cc => cc.Id == courseCreditingId).SingleOrDefaultAsync();
        if (model == null)
        {
            throw new Error404("CourseCrediting not found.");
        }
        model.EvaluatedByUserId = null;
        model.Status = GlobalValidityStatusEnum.REJECTED;
        return await UpdateAsync(model);
    }

    public async Task<object> ReturnByUserAndId(string userId, int courseCreditingId)
    {
        var model = await _dbModel.Where(cc => cc.Id == courseCreditingId).SingleOrDefaultAsync();
        if (model == null)
        {
            throw new Error404("CourseCrediting not found.");
        }
        model.EvaluatedByUserId = null;
        model.Status = GlobalValidityStatusEnum.RETURNED;
        return await UpdateAsync(model);
    }

    public async Task<object> RevertByUserAndId(string userId, int courseCreditingId)
    {
        var model = await _dbModel.Where(cc => cc.Id == courseCreditingId).SingleOrDefaultAsync();
        if (model == null)
        {
            throw new Error404("CourseCrediting not found.");
        }
        switch (model.Status)
        {
            case GlobalValidityStatusEnum.APPROVED:
            case GlobalValidityStatusEnum.REJECTED:
            case GlobalValidityStatusEnum.RETURNED:
                model.Status = GlobalValidityStatusEnum.PENDING;
                break;
        }
        return await UpdateAsync(model);
    }

    public async Task<object> GetCourseCreditingByStatusAndAssignToUserId(GlobalValidityStatusEnum status, string userId)
    {
        return _mapper.Map<ICollection<GetCourseCreditingDto>>(await _dbModel.Include(d => d.Course).Include(d => d.CreditedFromSchool).Where(cc => cc.Status == status && cc.CreditToUserId == userId).ToListAsync());
    }
}
