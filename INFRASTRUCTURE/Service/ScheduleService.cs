using APPLICATION.Dto.Schedule;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace INFRASTRUCTURE.Service;
public class ScheduleService:GenericService<Schedule, GetScheduleDto>, IScheduleService
{
    public ScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<Schedule?> GetAsync(int id)
    {
        return _mapper.Map<Schedule?>(await _dbModel
            .Include(s => s.Cycle)
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync());
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

    public async Task<ICollection<GetScheduleDto>> GetSectionsBySectionNameAndCycleId(string sectionName, int cycleId)
    {
        return _mapper.Map<ICollection<GetScheduleDto>>(await _dbModel
            .Include(s => s.AcademicProgram)
            .Include(s => s.Course)
            .Include(s => s.Room)
                .ThenInclude(room => room.Building)
            .Include(s => s.Cycle)
            .Where(sched => sched.GeneratedSection == sectionName)
            .Where(sched => sched.CycleId == cycleId)
            .ToListAsync());
    }

    public async new Task<bool> CreateAllWithUserIdAsync(string userId, IList<Schedule> newItems)
    {
        foreach (var item in newItems)
        {
            item.CreatedByUserId = userId;
        }
        return await CreateAllAsync(newItems);
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

    public async Task<ICollection<GetScheduleDto>?> GenerateSchedule(string generatedByUserId, int numberOfSchedules, ScheduleGenerateDto schedules)
    {
        if (numberOfSchedules <= 0 || schedules.CurriculumDetailsId.Length <= 0)
        {
            return null;
        }

        List<ScheduleDto> preGenerated = new List<ScheduleDto>();

        var lastInsertedId = _dbModel
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefault();

        foreach (var sched in schedules.CurriculumDetailsId)
        {
            // Initialize suffix outside the loop to ensure it's updated properly
            char suffix = 'A';

            // Fetch curriculum including related entities in one query
            var curriculumDetails = _dbContext.CurriculumDetails
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.Campus)
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicTerm)
                .First(cd => cd.Id == sched); // Use First instead of Where + First

            // Get the already inserted count from the database in one query
            var alreadyInserted = _dbModel
                .Where(s => s.CycleId == schedules.CycleId && s.AcademicProgramId == curriculumDetails.Curriculum.AcademicProgramId)
                .Count();

            for (var i = 0; i < numberOfSchedules; i++)
            {
                // Increment the suffix to ensure uniqueness based on already inserted
                char currentSuffix = (char)('A' + alreadyInserted + i);

                var numberPart = (alreadyInserted + i) / 26; // If suffix exceeds 'Z', we add number parts
                var suffix2 = numberPart > 0 ? numberPart.ToString() : "";

                var referenceBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(curriculumDetails.Curriculum.AcademicProgram.College.Campus.CampusShortName)
                    .Append('_')
                    .Append(PrefixAZero(schedules.CycleId))
                    .Append('_')
                    .Append(lastInsertedId + preGenerated.Count + 1); // Adjust based on the preGenerated list size

                var sectionBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(currentSuffix)
                    .Append(suffix2); // Handle extra suffix if needed

                // Add to the list
                preGenerated.Add(new ScheduleDto
                {
                    AcademicProgramId = curriculumDetails.Curriculum.AcademicProgramId,
                    CycleId = schedules.CycleId,
                    CourseId = curriculumDetails.CourseId,
                    GeneratedReference = referenceBuilder.ToString(),
                    GeneratedSection = sectionBuilder.ToString(),
                });
            }

            // Ensure the suffix increments properly for next sched in CurriculumDetailsId
            suffix = (char)(suffix == 'Z' ? 'A' : suffix + 1);
        }

        // Ensure that the number of schedules matches the expected number
        if ((numberOfSchedules * schedules.CurriculumDetailsId.Length) != preGenerated.Count)
        {
            return null;
        }

        var items = _mapper.Map<ICollection<Schedule>>(preGenerated);

        // Set created by user ID
        foreach (var item in items)
        {
            item.CreatedByUserId = generatedByUserId;
        }

        var result = await CreateAllAsync(items.ToArray());

        if (result)
        {
            var academicProgramIds = items.Select(item => item.AcademicProgramId).Distinct().ToList();
            var cycleIds = items.Select(item => item.CycleId).Distinct().ToList();

            var academicPrograms = _dbContext.AcademicPrograms
                .Where(ap => academicProgramIds.Contains(ap.Id))
                .ToDictionary(ap => ap.Id);

            var cycles = _dbContext.Cycles
                .Where(c => cycleIds.Contains(c.Id))
                .ToDictionary(c => c.Id);

            foreach (var item in items)
            {
                item.AcademicProgram = academicPrograms[item.AcademicProgramId];
                item.Cycle = cycles[item.CycleId];
            }
        }

        return result
            ? _mapper.Map<ICollection<GetScheduleDto>>(items)
            : null;
    }

    public string PrefixAZero(int id)
    {
        int numberOfDigits = 6;
        return id.ToString().PadLeft(numberOfDigits, '0');
    }
}
