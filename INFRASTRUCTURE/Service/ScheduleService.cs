using APPLICATION.Dto.Schedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class ScheduleService:GenericService<Schedule, GetScheduleDto>, IScheduleService
{
    public ScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetScheduleDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .ToListAsync());
    }

    public async Task<ICollection<GetScheduleDto>> GetByCreatedByUserId(string createdByUserId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.CreatedByUserId == createdByUserId)
            .ToListAsync());
    }

    public async new Task<GetScheduleDto?> GetAsync(int id)
    {
        return _mapper.Map<GetScheduleDto?>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(sched => sched.Id == id).FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(Schedule newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.AcademicProgram = await _dbContext.AcademicPrograms.FindAsync(newItem.AcademicProgramId);
            newItem.Cycle = await _dbContext.Cycles.FindAsync(newItem.CycleId);
            if (newItem.CourseId != null)
                newItem.Course = await _dbContext.Courses.FindAsync(newItem.CourseId);
            if (newItem.RoomId != null)
                newItem.Room = await _dbContext.Rooms.FindAsync(newItem.RoomId);
            if (newItem.Room != null)
            {
                newItem.Room.Building = await _dbContext.Buildings.FindAsync(newItem.Room.BuildingId);
            }
        }
        return result;
    }

    public async new Task<bool> CreateAllAsync(IList<Schedule> newItems)
    {
        await _dbModel.AddRangeAsync(newItems);
        var result = await Save();
        if (result)
        {
            foreach (var item in newItems)
            {
                item.AcademicProgram = _dbContext.AcademicPrograms.Find(item.AcademicProgramId);
                item.Cycle = _dbContext.Cycles.Find(item.CycleId);
                
                if (item.CourseId != null)
                    item.Course = _dbContext.Courses.Find(item.CourseId);
                if (item.RoomId != null)
                    item.Room = _dbContext.Rooms.Find(item.RoomId);
                if (item.Room != null)
                {
                    item.Room.Building = _dbContext.Buildings.Find(item.Room.BuildingId);
                }
            }
        }
        return result;
    }

    public async new Task<bool> UpdateSync(Schedule updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.AcademicProgram = await _dbContext.AcademicPrograms.FindAsync(updatedItem.AcademicProgramId);
            updatedItem.Cycle = await _dbContext.Cycles.FindAsync(updatedItem.CycleId);
            if (updatedItem.CourseId != null)
                updatedItem.Course = await _dbContext.Courses.FindAsync(updatedItem.CourseId);
            if (updatedItem.RoomId != null)
                updatedItem.Room = await _dbContext.Rooms.FindAsync(updatedItem.RoomId);
            if (updatedItem.Room != null)
            {
                updatedItem.Room.Building = await _dbContext.Buildings.FindAsync(updatedItem.Room.BuildingId);
            }
        }
        return result;
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.AcademicProgramId == academicProgramId)
            .ToListAsync());
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByRoomId(int roomId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.RoomId == roomId)
            .ToListAsync());
    }
    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.CycleId == cycleId)
            .ToListAsync());
    }
    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.CourseId == courseId)
            .ToListAsync());
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCampusId(int campusId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
                .ThenInclude(ap => ap.College)
                    .ThenInclude(c => c.Campus)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(s => s.AcademicProgram.College.CampusId == campusId)
            .Select(s => new Schedule
            {
                Id = s.Id,
                GeneratedSection = s.GeneratedSection,
                GeneratedReference = s.GeneratedReference,
                AcademicProgram = new AcademicProgram {
                    Id = s.AcademicProgram.Id,
                    ProgramName = s.AcademicProgram.ProgramName,
                    ShortName = s.AcademicProgram.ShortName,
                    YearFirstImplemented = s.AcademicProgram.YearFirstImplemented,
                },
                CourseId = s.CourseId,
                Course = s.Course,
                //
                RoomId = s.RoomId,
                Room = s.Room,
                //
                CycleId = s.CycleId,
                Cycle = s.Cycle
            })
            .ToListAsync());
    }

    public async Task<ICollection<GetScheduleDto>?> GenerateSchedule(string generatedByUserId, List<ScheduleDto> schedules)
    {
        var items = _mapper.Map<ICollection<Schedule>>(schedules);
        foreach (var item in items)
        {
            item.CreatedByUserId = generatedByUserId;
        }
        var result = await CreateAllAsync([.. items]);
        if (result)
        {
            foreach (var item in items)
            {
                item.AcademicProgram = _dbContext.AcademicPrograms.Find(item.AcademicProgramId);
                item.Cycle = _dbContext.Cycles.Find(item.CycleId);
            }
        }
        return (result)
            ? _mapper.Map<ICollection<GetScheduleDto>>(items)
            : null;
    }
}
