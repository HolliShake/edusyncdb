
using APPLICATION.Dto.ScheduleAssignment;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleAssignmentService:GenericService<ScheduleAssignment, GetScheduleAssignmentDto>, IScheduleAssignmentService
{
    public ScheduleAssignmentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> CreateScheduleAssignmentByMergeCode(string mergeCode, ScheduleAssignmentMergeCodeDto item) 
    {
        // Step 1: Retrieve all necessary data for pending assignments in one query
        var mergedSchedules = await _dbContext.ScheduleMerges
            .Where(sm => sm.MergeCode == mergeCode)
            .AsNoTracking()
            .Select(sm => sm.ScheduleId) // Only fetch ScheduleId to minimize data transfer
            .Distinct()
            .ToListAsync();

        // Step 2: Create pending assignments directly from the filtered data
        var pendingAssignments = mergedSchedules.Select(scheduleId => new ScheduleAssignment {
            ScheduleId = scheduleId,
            RoomId = item.RoomId,         // Ensure `item` is accessible and correctly defined
            DaySchedule = item.DaySchedule,
            TimeScheduleIn = item.TimeScheduleIn,
            TimeScheduleOut = item.TimeScheduleOut,
            ExpiryDate = item.ExpiryDate,
            MergeCode = mergeCode
        }).ToList();

        // Step 3: Batch insert all pending assignments
        return await CreateAllAsync(pendingAssignments);
    }

    public async Task<object> DeleteScheduleAssignmentByMergeCode(string mergeCode) 
    {
        // Step 1: Get distinct ScheduleIds for the given merge code
        var scheduleIds = await _dbContext.ScheduleMerges
            .Where(sm => sm.MergeCode == mergeCode)
            .Select(sm => sm.ScheduleId)
            .Distinct()
            .ToListAsync();

        // Step 2: Get all pending assignments for the retrieved ScheduleIds in one query
        var pendingAssignments = await _dbModel
            .Where(sa => sa.MergeCode == mergeCode && scheduleIds.Contains(sa.ScheduleId))
            .AsNoTracking()
            .ToListAsync();

        // Step 3: Remove the pending assignments
        _dbModel.RemoveRange(pendingAssignments);

        // Step 4: Save changes to the database
        return await Save();
    }
}
