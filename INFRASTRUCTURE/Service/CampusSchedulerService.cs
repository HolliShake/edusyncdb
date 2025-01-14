
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusScheduler;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CampusSchedulerService:GenericService<CampusScheduler, GetCampusSchedulerDto>, ICampusSchedulerService
{
    public CampusSchedulerService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<ICollection<GetCampusDto>> GetCampusesByUserId(string userId) 
    {
        return _mapper.Map<ICollection<GetCampusDto>>(await _dbModel
            .Include(cs => cs.Campus)
            .Where(cs => cs.SchedulerUserId == userId)
            .Select(cs => cs.Campus)
            .Distinct()
            .AsNoTracking()
            .ToListAsync());
    }

    public async Task<object> GetMergedSchedulesBySchedulerUserAndCampusId(string userId, int campusId) 
    {
        // Step 1: Query schedules with necessary filters and tracking
        var uniqueScheduleIds = await _dbModel
            .Where(cs => cs.SchedulerUserId == userId && cs.CampusId == campusId)
            .Select(cs => cs.ScheduleAssignment.ScheduleId)
            .Distinct()
            .ToListAsync();

        // Step 2: Query merged schedules with filtered IDs
        var mergedSchedules = await _dbContext.ScheduleMerges
            .Include(sm => sm.Schedule)
                .ThenInclude(s => s.ScheduleAssignments)
            .Where(sm => uniqueScheduleIds.Contains(sm.ScheduleId)) // Filter directly in the database
            .GroupBy(sm => sm.MergeCode)
            .ToListAsync();

        // Step 3: Process schedules in-memory
        return mergedSchedules.Select(g =>
        {
            var assignments = g.SelectMany(sm => sm.Schedule.ScheduleAssignments)
                .Select(sa => new {
                    sa.RoomId,
                    sa.Room,
                    sa.DaySchedule,
                    sa.TimeScheduleIn,
                    sa.TimeScheduleOut,
                    sa.ExpiryDate
                })
                .GroupBy(a => new { a.RoomId, a.DaySchedule, a.TimeScheduleIn, a.TimeScheduleOut, a.ExpiryDate }) // Group by all properties
                .Where(group => group.Count() == g.Count()) // Only keep schedules that are identical across all merged schedules
                .Select(group => group.Key) // Select the grouped key (unique schedules)
                .ToList();

            return new {
                MergeCode = g.Key,
                MergedSchedules = g.Select(sm => new
                {
                    Id = sm.Schedule.Id,
                    GeneratedReference = sm.Schedule.GeneratedReference,
                    GeneratedSection = sm.Schedule.GeneratedSection,
                }),
                ScheduleAssignments = assignments // Assign filtered assignments here
            };
        });
    }

    public async Task<object> GetClassScheduleBySchedulerUserAndCampusId(string userId, int campusId) 
    {
        var result = await _dbModel
            .Include(s => s.ScheduleAssignment)
                .ThenInclude(sa => sa.Schedule)
            .Where(cs => cs.SchedulerUserId == userId)
            .Where(cs => cs.CampusId == campusId)
            .AsNoTracking()
            .ToListAsync();
        return result.GroupBy(cs => cs.ScheduleAssignment.Schedule)
            .Select(g =>
            {
                var items = g.Select(cs => cs.ScheduleAssignment)
                    .Where(sa => sa.ExpiryDate == null)
                    .ToList();
                return new {
                    g.Key.Id,
                    g.Key.GeneratedReference,
                    g.Key.GeneratedSection,
                    g.Key.MinStudent,
                    g.Key.MaxStudent,
                    g.Key.IsPetitionSchedule,
                    g.Key.IsExclusive,
                    g.Key.CreatedByUserId,
                    g.Key.CreatedByUser,
                    g.Key.CycleId,
                    g.Key.Cycle,
                    g.Key.CurriculumDetailId,
                    g.Key.CurriculumDetail,
                    ScheduleAssignments = items
                };
            });
    }

    public async Task<object> GetExamScheduleBySchedulerUserAndCampusId(string userId, int campusId) {
        var result = await _dbModel
            .Include(s => s.ScheduleAssignment)
                .ThenInclude(sa => sa.Schedule)
            .Where(cs => cs.SchedulerUserId == userId)
            .Where(cs => cs.CampusId == campusId)
            .AsNoTracking()
            .ToListAsync();
        return result.GroupBy(cs => cs.ScheduleAssignment.Schedule)
            .Select(g => {
                var items = g.Select(cs => cs.ScheduleAssignment)
                    .Where(sa => sa.ExpiryDate != null)
                    .Where(sa => sa.ExpiryDate <= DateTime.Now)
                    .ToList();
                return new {
                    g.Key.Id,
                    g.Key.GeneratedReference,
                    g.Key.GeneratedSection,
                    g.Key.MinStudent,
                    g.Key.MaxStudent,
                    g.Key.IsPetitionSchedule,
                    g.Key.IsExclusive,
                    g.Key.CreatedByUserId,
                    g.Key.CreatedByUser,
                    g.Key.CycleId,
                    g.Key.Cycle,
                    g.Key.CurriculumDetailId,
                    g.Key.CurriculumDetail,
                    ScheduleAssignments = items
                };
            });
    }
}
