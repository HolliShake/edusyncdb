using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using APPLICATION.Dto.Schedule;
using APPLICATION.IService.SchedulingData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.SchedulingData;

public class ScheduleService:GenericService<Schedule, GetScheduleDto>, IScheduleService
{
    public ScheduleService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<Schedule?> GetAsync(int id)
    {
        var schedule = await _dbModel
        .Include(s => s.Cycle)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Where(s => s.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return schedule;
    }

    public async new Task<ICollection<GetScheduleDto>> GetAllAsync()
    {
        var schedules = await _dbModel
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .AsNoTracking() // Add AsNoTracking for performance if you're only reading data
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(schedules);
    }

    public async new Task<GetScheduleDto?> CreateAsync(Schedule newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Cycle = _dbContext.Cycles.Find(newItem.CycleId);
            newItem.CurriculumDetail = _dbContext.CurriculumDetails
                .Include(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                .Where(s => s.Id == newItem.CurriculumDetailId)
                .SingleOrDefault();
            return _mapper.Map<GetScheduleDto>(newItem);
        }
        return null;
    }

    public async new Task<ICollection<GetScheduleDto>?> CreateAllAsync(List<Schedule> newItems)
    {
        await _dbModel.AddRangeAsync(newItems);
        if (await Save())
        {
            foreach (var item in newItems)
            {
                item.Cycle = _dbContext.Cycles.Find(item.CycleId);
                item.CurriculumDetail = _dbContext.CurriculumDetails
                    .Include(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                    .Where(cd => cd.Id == item.CurriculumDetailId)
                    .SingleOrDefault();
            }
            return _mapper.Map<ICollection<GetScheduleDto>>(newItems);
        }
        return null;
    }

    public async new Task<GetScheduleDto?> UpdateAsync(Schedule updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Cycle = _dbContext.Cycles.Find(updatedItem.CycleId);
            updatedItem.CurriculumDetail = _dbContext.CurriculumDetails
                .Include(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                .Where(cd => cd.Id == updatedItem.CurriculumDetailId)
                .SingleOrDefault();
            return _mapper.Map<GetScheduleDto>(updatedItem);
        }
        return null;
    }

    //=======================================
    public async Task<object> GetScheduleByRoom(int roomId)
    {
        var result = await _dbModel
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.ScheduleAssignments)
            .ThenInclude(sa => sa.Room)
        .Include(s => s.Cycle)
        .Where(s => s.ScheduleAssignments.Any(sa => sa.RoomId == roomId))
        .AsNoTracking()
        .Select(s => new
        {
            s.Id,
            s.CurriculumDetailId,
            s.CurriculumDetail,
            s.CycleId,
            s.Cycle,
            s.CreatedByUserId,
            s.CreatedByUser,
            s.IsExclusive,
            s.IsPetitionSchedule,
            s.MaxStudent,
            s.MinStudent,
            s.GeneratedReference,
            s.GeneratedSection,
            ScheduleAssignments = s.ScheduleAssignments.Where(sa => sa.RoomId == roomId).ToList()
        })
        .ToListAsync();
        return result;
    }

    public async Task<bool> CreateAllWithUserIdAsync(string userId, List<Schedule> newItems)
    {
        foreach (var item in newItems)
        {
            item.CreatedByUserId = userId;
        }
        return (await CreateAllAsync(newItems)) != null;
    }

    public async Task<ICollection<GetScheduleDto>> GetByCreatedByUserId(string createdByUserId)
    {
        var createdByUser = await _dbModel
        .Where(s => s.CreatedByUserId == createdByUserId) // Apply filtering early
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .AsNoTracking() // Use this to improve performance for read-only data
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(createdByUser);
    }

    public async Task<object> GetSchedulesByCampusId(int campusId)
    {
        return await _dbModel
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.Campus)
            .Include(s => s.Cycle)
            .Include(s => s.ScheduleAssignments)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == campusId)
            .Select(s => new
            {
                Id = s.Id,
                GeneratedSection = s.GeneratedSection,
                GeneratedReference = s.GeneratedReference,
                AcademicProgram = new AcademicProgram
                {
                    Id = s.CurriculumDetail.Curriculum.AcademicProgram.Id,
                    ProgramName = s.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                    ShortName = s.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
                    YearFirstImplemented = s.CurriculumDetail.Curriculum.AcademicProgram.YearFirstImplemented,
                },
                CourseId = s.CurriculumDetail.CourseId,
                Course = s.CurriculumDetail.Course,
                //
                CycleId = s.CycleId,
                Cycle = s.Cycle
            })
            .ToListAsync();
    }

    public async Task<object> GetSchedulesByCampusAndCycleId(int campusId, int cycleId)
    {
        return await _dbModel
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.Campus)
            .Include(s => s.Cycle)
            .Include(s => s.ScheduleAssignments)
            .Where(s => s.CurriculumDetail.Curriculum.AcademicProgram.College.CampusId == campusId)
            .Where(s => s.CycleId == cycleId)
            .Select(s => new
            {
                Id = s.Id,
                GeneratedSection = s.GeneratedSection,
                GeneratedReference = s.GeneratedReference,
                AcademicProgram = new AcademicProgram
                {
                    Id = s.CurriculumDetail.Curriculum.AcademicProgram.Id,
                    ProgramName = s.CurriculumDetail.Curriculum.AcademicProgram.ProgramName,
                    ShortName = s.CurriculumDetail.Curriculum.AcademicProgram.ShortName,
                    YearFirstImplemented = s.CurriculumDetail.Curriculum.AcademicProgram.YearFirstImplemented,
                },
                CourseId = s.CurriculumDetail.CourseId,
                Course = s.CurriculumDetail.Course,
                //
                CycleId = s.CycleId,
                Cycle = s.Cycle
            })
            .ToListAsync();
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesBySectionNameAndCycleId(string sectionName, int cycleId)
    {
        var schedules = await _dbModel
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .Where(sched => sched.GeneratedSection == sectionName)
        .Where(sched => sched.CycleId == cycleId)
        .AsNoTracking() // Improves performance for read-only queries
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(schedules);
    }

    public async Task<object> GetSchedulesByCurriculumAndCycleIdAndYearLevel(int curriculumId, int cycleId, int yearLevel)
    {
        var schedules = await _dbModel
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
            .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Include(s => s.Cycle)
            .Where(s => s.CurriculumDetail.CurriculumId == curriculumId)
            .Where(s => s.CycleId == cycleId)
            .Where(s => s.CurriculumDetail.YearLevel == yearLevel)
            .AsNoTracking() // Improves performance for read-only queries
            .ToListAsync();

        // Group the schedules by the generated section and reshape the data
        var reshapedData = schedules
            .GroupBy(s0 => s0.GeneratedSection) // Group by the generated section
            .Select(section => new
            {
                GeneratedSection = section.Key, // Section name
                Courses = section
                    .Select(s1 => new
                    {
                        CourseId = s1.CurriculumDetail.Course.Id,
                        Course = new
                        {
                            Id = s1.CurriculumDetail.Course.Id,
                            CourseTitle = s1.CurriculumDetail.Course.CourseTitle,
                            CourseCode = s1.CurriculumDetail.Course.CourseCode,
                            CourseDescription = s1.CurriculumDetail.Course.CourseDescription,
                            LectureUnits = s1.CurriculumDetail.Course.LectureUnits,
                            LaboratoryUnits = s1.CurriculumDetail.Course.LaboratoryUnits,
                            CreditUnits = s1.CurriculumDetail.Course.CreditUnits,
                            WeeklySchedules = section
                                .Where(s2 => s2.GeneratedSection == section.Key)
                                .Where(s2 => s2.CycleId == cycleId)
                                .Where(s2 => s2.CurriculumDetail.CourseId == s1.CurriculumDetail.CourseId)
                                .Select(sched => new
                                {
                                    Id = sched.Id,
                                    GeneratedReference = sched.GeneratedReference,
                                    MinStudent = sched.MinStudent,
                                    MaxStudent = sched.MaxStudent,
                                    IsPetitionSchedule = sched.IsPetitionSchedule,
                                    IsExclusive = sched.IsExclusive
                                }).ToList()
                        }
                    }).ToList()
            }).ToList();

        return reshapedData;

    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByAcademicProgramId(int academicProgramId)
    {
        var schedules = await _dbModel
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .Where(s => s.CurriculumDetail.Curriculum.AcademicProgramId == academicProgramId) // Apply filter early
        .AsNoTracking() // Add for read-only data to improve performance
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(schedules);
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCycleId(int cycleId)
    {
        var schedules = await _dbModel
        .Include(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .Where(s => s.CycleId == cycleId)
        .AsNoTracking() // Add for read-only data to improve performance
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(schedules);
    }

    public async Task<ICollection<GetScheduleDto>> GetSchedulesByCourseId(int courseId)
    {
        var schedules = await _dbModel
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Course)
        .Include(s => s.CurriculumDetail)
            .ThenInclude(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
        .Include(s => s.Cycle)
        .Where(s => s.CurriculumDetail.CourseId == courseId)
        .AsNoTracking() // Add for read-only data to improve performance
        .ToListAsync();
        return _mapper.Map<ICollection<GetScheduleDto>>(schedules);
    }

    public async Task<GetScheduleDto?> AddAnotherSchedule(string generatedReference)
    {
        var current = await _dbModel
            .Where(s => s.GeneratedReference == generatedReference)
            .SingleOrDefaultAsync();
        if (current == null)
        {
            return null;
        }
        var copy = new Schedule 
        { 
            GeneratedReference = current.GeneratedReference,
            GeneratedSection = current.GeneratedSection,
            CycleId = current.CycleId,
            CreatedByUser = current.CreatedByUser,
            CreatedByUserId = current.CreatedByUserId,
            CurriculumDetail = current.CurriculumDetail,
            CurriculumDetailId = current.CurriculumDetailId,
        };
        return await CreateAsync(copy);
    }

    public async Task<object?> AddSection(string generatedByUserId, ScheduleGenerateDto schedules)
    {
        if (schedules.CurriculumDetailsId.Length <= 0)
        {
            return null;
        }

        // List to hold the generated schedule
        List<ScheduleDto> preGenerated = new();

        // Get the last inserted ID from the database
        var lastInsertedId = _dbModel
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefault();

        // Initialize suffix to continue section generation
        int suffixIndex = 0;
        string currentSuffix = "";

        foreach (var sched in schedules.CurriculumDetailsId)
        {
            // Fetch curriculum details including related entities
            var curriculumDetails = await _dbContext.CurriculumDetails
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.Campus)
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicTerm)
                .FirstOrDefaultAsync(cd => cd.Id == sched);

            // Fetch existing schedules for this Cycle and CurriculumDetail
            var existingSchedules = await _dbModel
                .Where(s => s.CycleId == schedules.CycleId && s.CurriculumDetailId == sched)
                .ToListAsync();

            // Calculate the next section suffix based on existing schedules
            suffixIndex = existingSchedules.Count; // Count existing schedules
            currentSuffix = GetSectionSuffix(suffixIndex); // Generate suffix like A, B, ..., Z, A1, etc.

            // Build the reference
            var referenceBuilder = new StringBuilder()
                .Append(curriculumDetails.Curriculum.CurriculumCode)
                .Append('_')
                .Append(curriculumDetails.Curriculum.AcademicProgram.College.Campus.CampusShortName)
                .Append('_')
                .Append(PrefixAZero(schedules.CycleId))
                .Append('_')
                .Append(lastInsertedId + 1); // Increment the ID

            // Build the section name
            var sectionBuilder = new StringBuilder()
                .Append(curriculumDetails.Curriculum.CurriculumCode)
                .Append('_')
                .Append(currentSuffix); // Add suffix for unique section

            // Add the new schedule to the list
            preGenerated.Add(new ScheduleDto
            {
                CycleId = schedules.CycleId,
                CurriculumDetailId = curriculumDetails.Id,
                GeneratedReference = referenceBuilder.ToString(),
                GeneratedSection = sectionBuilder.ToString(),
            });
        }

        if (preGenerated.IsNullOrEmpty())
        {
            return null;
        }

        // Map to Schedule entities
        var items = _mapper.Map<ICollection<Schedule>>(preGenerated);

        // Set CreatedByUserId for each item
        foreach (var item in items)
        {
            item.CreatedByUserId = generatedByUserId;
        }

        var itemsArray = items.ToList();

        // Save the schedules to the database
        var result = await CreateAllAsync(itemsArray);

        if (result == null)
        {
            return null;
        }

        var curriculumDetailsIds = itemsArray.Select(item => item.CurriculumDetailId).Distinct().ToList();
        var cycleIds = itemsArray.Select(item => item.CycleId).Distinct().ToList();

        // Fetch AcademicPrograms and Cycles from the database
        var curriculumDetailsDict = await _dbContext.CurriculumDetails
            .Include(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
            .Where(cd => curriculumDetailsIds.Contains(cd.Id))
            .ToDictionaryAsync(cd => cd.Id);

        var cycles = await _dbContext.Cycles
            .Where(c => cycleIds.Contains(c.Id))
            .ToDictionaryAsync(c => c.Id);

        foreach (var item in items)
        {
            item.CurriculumDetail = curriculumDetailsDict[item.CurriculumDetailId];
            item.Cycle = cycles[item.CycleId];
        }

        return (itemsArray.GroupBy(s0 => s0.GeneratedSection) // Group by the generated section
            .Select(section => new
            {
                GeneratedSection = section.Key, // Section name
                Courses = section
                    .Select(s1 => new
                    {
                        CourseId = s1.CurriculumDetail.Course.Id,
                        Course = new
                        {
                            Id = s1.CurriculumDetail.Course.Id,
                            CourseTitle = s1.CurriculumDetail.Course.CourseTitle,
                            CourseCode = s1.CurriculumDetail.Course.CourseCode,
                            CourseDescription = s1.CurriculumDetail.Course.CourseDescription,
                            LectureUnits = s1.CurriculumDetail.Course.LectureUnits,
                            LaboratoryUnits = s1.CurriculumDetail.Course.LaboratoryUnits,
                            CreditUnits = s1.CurriculumDetail.Course.CreditUnits,
                            WeeklySchedules = section
                                .Where(s2 => s2.GeneratedSection == section.Key)
                                .Where(s2 => s2.CycleId == s1.CycleId)
                                .Where(s2 => s2.CurriculumDetail.CourseId == s1.CurriculumDetail.CourseId)
                                .Select(sched => new
                                {
                                    Id = sched.Id,
                                    GeneratedReference = sched.GeneratedReference,
                                    MinStudent = sched.MinStudent,
                                    MaxStudent = sched.MaxStudent,
                                    IsPetitionSchedule = sched.IsPetitionSchedule,
                                    IsExclusive = sched.IsExclusive
                                }).ToList()
                        }
                    }).ToList()
            }).ToList());
    }

    public async Task<bool> DeleteSectionBySectionNameAndCycleId(string sectionName, int cycleId)
    {
        var items = await _dbModel
            .Where(sched => sched.GeneratedSection == sectionName)
            .Where(sched => sched.CycleId == cycleId)
            .ToListAsync();
        if (items.IsNullOrEmpty())
        {
            return false;
        }
        _dbModel.RemoveRange(items);
        return await Save();
    }

    public async Task<object?> GenerateSchedule(string generatedByUserId, int numberOfSchedules, ScheduleGenerateDto schedules)
    {
        if (numberOfSchedules <= 0 || schedules.CurriculumDetailsId.Length <= 0)
        {
            return null;
        }

        List<ScheduleDto> preGenerated = new();

        // Get the last inserted ID from the database
        var lastInsertedId = _dbModel
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefault();

        // Initialize suffix outside the loop to handle continuous generation
        int suffixIndex = 0;
        int existingCount = 0;

        for (var i = 0; i < numberOfSchedules; i++)
        {
            // Calculate current suffix index and handle overflow when exceeding 'Z'
            int totalIndex = suffixIndex + i;
            string currentSuffix = GetSectionSuffix(totalIndex); // Get suffix like A, B, ... Z, A1, B1, etc.

            foreach (var sched in schedules.CurriculumDetailsId)
            {
                // Fetch curriculum details including related entities
                var curriculumDetails = _dbContext.CurriculumDetails
                    .Include(curr => curr.Curriculum)
                        .ThenInclude(curr => curr.AcademicProgram)
                            .ThenInclude(ap => ap.College)
                                .ThenInclude(c => c.Campus)
                    .Include(curr => curr.Curriculum)
                        .ThenInclude(curr => curr.AcademicTerm)
                    .FirstOrDefault(cd => cd.Id == sched); // Get the curriculum details

                // Build the reference
                var referenceBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(curriculumDetails.Curriculum.AcademicProgram.College.Campus.CampusShortName)
                    .Append('_')
                    .Append(PrefixAZero(schedules.CycleId))
                    .Append('_')
                    .Append(lastInsertedId + preGenerated.Count + 1); // Add based on preGenerated list size

                // Build the section name
                var sectionBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(currentSuffix); // Append suffix

                var exists = _dbModel
                    .Any(s => 
                        s.CurriculumDetailId == curriculumDetails.Id &&
                        s.CycleId == schedules.CycleId &&
                        s.GeneratedSection == sectionBuilder.ToString());

                // Add the new schedule to the list
                if (!exists)
                {
                    preGenerated.Add(new ScheduleDto
                    {
                        CycleId = schedules.CycleId,
                        CurriculumDetailId = curriculumDetails.Id,
                        GeneratedReference = referenceBuilder.ToString(),
                        GeneratedSection = sectionBuilder.ToString(),
                    });
                } else
                {
                    ++existingCount;
                }
            }
        }

        if (preGenerated.IsNullOrEmpty())
        {
            return (ICollection<object>)[];
        }

        // Map to Schedule entities
        var items = _mapper.Map<ICollection<Schedule>>(preGenerated);

        // Set CreatedByUserId for each item
        foreach (var item in items)
        {
            item.CreatedByUserId = generatedByUserId;
        }

        var itemsArray = items.ToList();

        // Save the schedules to the database
        var result = await CreateAllAsync(itemsArray);

        if (result == null)
        {
            return null;
        }

        var curriculumDetailsIds = itemsArray.Select(item => item.CurriculumDetailId).Distinct().ToList();
        var cycleIds = itemsArray.Select(item => item.CycleId).Distinct().ToList();

        // Fetch AcademicPrograms and Cycles from the database
        var curriculumDetailsDict = _dbContext.CurriculumDetails
            .Include(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
            .Where(cd => curriculumDetailsIds.Contains(cd.Id))
            .ToDictionary(cd => cd.Id);

        var cycles = _dbContext.Cycles
            .Where(c => cycleIds.Contains(c.Id))
            .ToDictionary(c => c.Id);

        foreach (var item in itemsArray)
        {
            item.CurriculumDetail = curriculumDetailsDict[item.CurriculumDetailId];
            item.Cycle = cycles[item.CycleId];
        }

        return (itemsArray.GroupBy(s0 => s0.GeneratedSection) // Group by the generated section
            .Select(section => new
            {
                GeneratedSection = section.Key, // Section name
                Courses = section
                    .Select(s1 => new
                    {
                        CourseId = s1.CurriculumDetail.Course.Id,
                        Course = new
                        {
                            Id = s1.CurriculumDetail.Course.Id,
                            CourseTitle = s1.CurriculumDetail.Course.CourseTitle,
                            CourseCode = s1.CurriculumDetail.Course.CourseCode,
                            CourseDescription = s1.CurriculumDetail.Course.CourseDescription,
                            LectureUnits = s1.CurriculumDetail.Course.LectureUnits,
                            LaboratoryUnits = s1.CurriculumDetail.Course.LaboratoryUnits,
                            CreditUnits = s1.CurriculumDetail.Course.CreditUnits,
                            WeeklySchedules = section
                                .Where(s2 => s2.GeneratedSection == section.Key)
                                .Where(s2 => s2.CycleId == s1.CycleId)
                                .Where(s2 => s2.CurriculumDetail.CourseId == s1.CurriculumDetail.CourseId)
                                .Select(sched => new
                                {
                                    Id = sched.Id,
                                    GeneratedReference = sched.GeneratedReference,
                                    MinStudent = sched.MinStudent,
                                    MaxStudent = sched.MaxStudent,
                                    IsPetitionSchedule = sched.IsPetitionSchedule,
                                    IsExclusive = sched.IsExclusive
                                }).ToList()
                        }
                    }).ToList()
            }).ToList());
    }

    string GetSectionSuffix(int index)
    {
        char letter = (char)('A' + (index % 26)); // Get the letter from A to Z
        int numberPart = index / 26; // Calculate the numeric part

        return numberPart > 0 ? $"{letter}{numberPart}" : $"{letter}";
    }

    public string PrefixAZero(int id)
    {
        int numberOfDigits = 6;
        return id.ToString().PadLeft(numberOfDigits, '0');
    }
}
