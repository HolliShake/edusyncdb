using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.Campus;
using APPLICATION.Dto.CampusScheduler;
using APPLICATION.IService.DesignationData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;

namespace INFRASTRUCTURE.Service.DesignationData;

public class CampusSchedulerService:GenericService<CampusScheduler, GetCampusSchedulerDto>, ICampusSchedulerService
{
    public CampusSchedulerService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<bool> IsScheduler(string userId)
    {
        return await _dbModel.Where(sc => sc.SchedulerUserId == userId).AnyAsync();
    }

    public async new Task<ICollection<GetCampusSchedulerDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetCampusSchedulerDto>>(await _dbModel
            .Include(cs => cs.Campus)
            .Include(cs => cs.SchedulerUser)
            .ToListAsync());
    }

    public async Task<GetCampusDto> GetScheduleByUserId(string userId)
    {
        return await _dbModel
                .Include(cs => cs.Campus)
                .Where(cs => cs.SchedulerUserId == userId)
                .Select(cs => _mapper.Map<GetCampusDto>(cs.Campus))
                .SingleOrDefaultAsync();
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

    public async Task<object> GetBuildingWithinRoomsSchedulesByUserAndCampusId(string userId, int campusId)
    {
        var result = await _dbContext.Buildings
        .Include(b => b.Rooms)
            .ThenInclude(r => r.ScheduleAssignments)
                .ThenInclude(sa => sa.Schedule)
                    .ThenInclude(s => s.CurriculumDetail)
                        .ThenInclude(cd => cd.Curriculum)
                            .ThenInclude(c => c.AcademicProgram)
                                .ThenInclude(ap => ap.College)
        .Where(b => b.CampusId == campusId) // Filter by CampusId
        .Select(b => new
        {
            BuildingId = b.Id,
            BuildingName = b.BuildingName,
            Longitude = b.Longitude,
            Latitude = b.Latitude,
            CampusId = b.CampusId,
            Campus = b.Campus,
            Rooms = b.Rooms.Select(r => new
            {
                RoomId = r.Id,
                RoomName = r.RoomName,
                Capacity = r.Capacity,
                BuildingId = r.BuildingId,
                Building = r.Building,
                IsLab = r.IsLab,
                IsEspecializedLab = r.IsEspecializedLab,
                ScheduleAssignments = r.ScheduleAssignments
                    .Where(sa => sa.Schedule.CreatedByUserId == userId) // Filter by userId
                    .Select(sa => new
                    {
                        ScheduleId = sa.Schedule.Id,
                        Schedule = sa.Schedule,
                        DaySchedule = sa.DaySchedule,
                        TimeScheduleIn = sa.TimeScheduleIn,
                        TimeScheduleOut = sa.TimeScheduleOut,
                        ExpiryDate = sa.ExpiryDate,
                        MergeCode = sa.MergeCode,
                        RoomId = sa.RoomId,
                        Room = sa.Room,
                    })
            })
        })
        .ToListAsync();

        return result;
    }

    public async Task<object> GetMergedSchedulesBySchedulerUserAndCampusId(string userId, int campusId) 
    { 
        var schedulerProfile = await _dbModel
            .Where(cs => cs.SchedulerUserId == userId && cs.CampusId == campusId)
            .SingleOrDefaultAsync();

        if (schedulerProfile == null)
        {
            throw new Error404("NotFound");
        }

        var schedules = await _dbContext.ScheduleMerges
                .Include(sm => sm.Schedule)
                .Where(sm => sm.Schedule.CreatedByUserId == schedulerProfile.SchedulerUserId)
                .GroupBy(sm => sm.MergeCode)
                .Select(sm => new
                {
                    MergeCode = sm.Key,
                    schedules = sm.Select(s => new
                    {
                        Id = s.ScheduleId,
                        GeneratedReference = s.Schedule.GeneratedReference,
                        GeneratedSection = s.Schedule.GeneratedSection,
                    }).ToList(),
                    MaxStudent = sm.Select(x => x.Schedule.MaxStudent).ToList().Sum(),
                    MinStudent = Math.Floor((float) sm.Select(x => x.Schedule.MaxStudent).ToList().Sum() / sm.Count()),
                    CycleId = sm.First().Schedule.CycleId,
                    Cycle = sm.First().Schedule.Cycle,
                    CurriculumDetailId = sm.First().Schedule.CurriculumDetailId,
                    CurriculumDetail = sm.First().Schedule.CurriculumDetail 
                }).ToListAsync();

        return schedules;
    }

    public async Task<object> GetClassScheduleBySchedulerUserAndCampusId(string userId, int campusId) 
    {
        var result = await _dbContext.Schedules
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                        .ThenInclude(ap => ap.College)
            .Include(s => s.ScheduleAssignments)
            .Where(s => s.CreatedByUserId == userId)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == campusId)
            .ToListAsync();

        return result.Select(g =>
            {
                return new
                {
                    g.Id,
                    g.GeneratedReference,
                    g.GeneratedSection,
                    g.MinStudent,
                    g.MaxStudent,
                    g.IsPetitionSchedule,
                    g.IsExclusive,
                    g.CreatedByUserId,
                    g.CreatedByUser,
                    g.CycleId,
                    g.Cycle,
                    g.CurriculumDetailId,
                    g.CurriculumDetail,
                    ScheduleAssignments = g.ScheduleAssignments.Where(sa => sa.ExpiryDate == null).ToList(),
                };
            });
    }

    public async Task<object> GetExamScheduleBySchedulerUserAndCampusId(string userId, int campusId) {
        var result = await _dbContext.Schedules
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.CampusId == campusId)
            .Include(s => s.ScheduleAssignments)
            .Where(s => s.CreatedByUserId == userId)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == campusId)
            .ToListAsync();

        return result.Select(g =>
        {
            return new
            {
                g.Id,
                g.GeneratedReference,
                g.GeneratedSection,
                g.MinStudent,
                g.MaxStudent,
                g.IsPetitionSchedule,
                g.IsExclusive,
                g.CreatedByUserId,
                g.CreatedByUser,
                g.CycleId,
                g.Cycle,
                g.CurriculumDetailId,
                g.CurriculumDetail,
                ScheduleAssignments = g.ScheduleAssignments
                    .Where(sa => sa.ExpiryDate != null)
                    .Where(sa => sa.ExpiryDate <= DateTime.Now)
                    .ToList()
            };
        });
    }
}
