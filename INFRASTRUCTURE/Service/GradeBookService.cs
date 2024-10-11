using APPLICATION.Dto.GradeBook;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GradeBookService:GenericService<GradeBook, GetGradeBookDto>, IGradeBookService
{
    public GradeBookService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object?> GenerateGradeBookFromTemplate(int scheduleId, int templateGradeBookId)
    {
        var hasOne = await _dbModel.AnyAsync(gb => gb.ScheduleId == scheduleId);
        if (hasOne)
        {
            throw new Exception("GradeBook already exists for this Schedule");
        }

        var templateGradeBook = _dbContext.TemplateGradeBooks
                .Include(tgb => tgb.TemplateGradeBookItems)
                    .ThenInclude(tgbi => tgbi.TemplateGradeBookItemDetails)
                        .ThenInclude(tgbid => tgbid.EqaAssessmentType)
                .Where(tgb => tgb.Id == templateGradeBookId)
                .FirstOrDefault();
        
        if (templateGradeBook == null)
        {
            throw new Exception("GradeBook Template not found");
        }

        var gradeBook = new GradeBook
        {
            GradeBookDescription = templateGradeBook.TemplateName,
            ScheduleId = scheduleId
        };

        if (!(await CreateAsync(gradeBook)))
        {
            return null;
        }

        var gradeBookItems = templateGradeBook.TemplateGradeBookItems.Select(t => new GradeBookItem
        {   GradeBookId = gradeBook.Id,
            ItemName = t.ItemName,
            Weight = t.Weight,
            GradingPeriodId = t.GradingPeriodId,
            GradingPeriod = _dbContext.GradingPeriods.Find(t.GradingPeriodId)
        }).ToList();

        _dbContext.GradeBookItems.AddRange(gradeBookItems);
        var wasSaved = await Save();

        if (!wasSaved || (templateGradeBook.TemplateGradeBookItems.Count != gradeBookItems.Count))
        {
           throw new Exception("GradeBook Items not saved");
        }

        List<GradeBookItemDetail> itemDetails = [];
        for (var i=0;i < gradeBookItems.Count;i++)
        {
            var item = templateGradeBook.TemplateGradeBookItems.ToList()[i];
            var savedItem = gradeBookItems[i];
            itemDetails.AddRange(item.TemplateGradeBookItemDetails.Select(d => new GradeBookItemDetail
            {
                GradeBookItemId = savedItem.Id,
                ItemDetail = d.ItemDetail,
                ItemDetailDescription = d.ItemDetailDescription,
                MaxScore = d.MaxScore,
                PassingScore = d.PassingScore,
                Weight = d.Weight,
                EqaAssessmentTypeId = d.EqaAssessmentTypeId,
                EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(d.EqaAssessmentTypeId)
            }));
        }

        _dbContext.GradeBookItemDetails.AddRange(itemDetails);
        var written = await Save();

        return (!written)
            ? null
            : new { 
                Id = gradeBook.Id,
                GradeBookDescription = gradeBook.GradeBookDescription,
                ScheduleId = gradeBook.ScheduleId,
                Schedule = new
                {
                    Id = gradeBook.Schedule.Id,
                    GeneratedReference = gradeBook.Schedule.GeneratedReference,
                    GeneratedSection = gradeBook.Schedule.GeneratedSection,
                    AcademicProgramId = gradeBook.Schedule.AcademicProgramId,
                    AcademicProgram = gradeBook.Schedule.AcademicProgram,
                    CourseId = gradeBook.Schedule.CourseId,
                    Course = gradeBook.Schedule.Course,
                    CycleId = gradeBook.Schedule.CycleId,
                    Cycle = gradeBook.Schedule.Cycle,
                    DaySchedule = gradeBook.Schedule.DaySchedule,
                    TimeScheduleIn = gradeBook.Schedule.TimeScheduleIn,
                    TimeScheduleOut = gradeBook.Schedule.TimeScheduleOut,
                    IsExclusive = gradeBook.Schedule.IsExclusive,
                    IsPetitionSchedule = gradeBook.Schedule.IsPetitionSchedule,
                    MaxStudent = gradeBook.Schedule.MaxStudent,
                    MinStudent = gradeBook.Schedule.MinStudent,
                    RoomId = gradeBook.Schedule.RoomId,
                    Room = gradeBook.Schedule.Room
                },
                // GradeBookItems Grouped By GradingPeriod
                GradingPeriods = gradeBookItems
                    .Select(gbi => gbi.GradingPeriod)
                    .Distinct()
                    .Select(gp => new
                    {
                        Id = gp.Id,
                        GradingPeriodDescription = gp.GradingPeriodDescription,
                        GradingNumber = gp.GradingNumber,
                        GradeBookItems = gradeBookItems
                            .Where(gbi => gbi.GradingPeriodId == gp.Id)
                            .Select(gbi => new
                            {
                                Id = gbi.Id,
                                ItemName = gbi.ItemName,
                                Weight = gbi.Weight,
                                GradingPeriodId = gbi.GradingPeriodId,
                                GradeBookItemDetails = itemDetails
                                    .Where(d => d.GradeBookItemId == gbi.Id)
                                    .Select(d => new
                                    {
                                        Id = d.Id,
                                        ItemDetail = d.ItemDetail,
                                        ItemDetailDescription = d.ItemDetailDescription,
                                        MaxScore = d.MaxScore,
                                        PassingScore = d.PassingScore,
                                        Weight = d.Weight,
                                        // Fk
                                        GradeBookItemId = d.GradeBookItemId,
                                        GradeBookItem = (GradeBookItem?) null,
                                        // Fk EqaAssessmentType
                                        EqaAssessmentTypeId = d.EqaAssessmentTypeId,
                                        EqaAssessmentType = d.EqaAssessmentType
                                    }).ToList()
                            }).ToList()
                    }).ToList()
            };
    }

    public async Task<object?> GetGradeBookByScheduleId(int scheduleId)
    {
        var item = _dbModel
        .Include(gb => gb.Schedule)
            .ThenInclude(s => s.Course)
        .Include(gb => gb.GradeBookItems)
             .ThenInclude(gbi => gbi.GradingPeriod)
        .Include(gb => gb.GradeBookItems)
            .ThenInclude(gbi => gbi.GradeBookItemDetails)
                .ThenInclude(gbid => gbid.EqaAssessmentType)
        .Where(gb => gb.ScheduleId == scheduleId)
        .FirstOrDefault();

        return (item == null)
            ? null
            : new
            {
                Id = item.Id,
                GradeBookDescription = item.GradeBookDescription,
                ScheduleId = item.ScheduleId,
                Schedule = new
                {
                    Id = item.Schedule.Id,
                    RoomId = item.Schedule.RoomId,
                    Room = item.Schedule.Room,
                    CourseId = item.Schedule.CourseId,
                    Course = item.Schedule.Course,  // Changed this to directly use the course from the included navigation property
                    AcademicProgramId = item.Schedule.AcademicProgramId,
                    AcademicProgram = item.Schedule.AcademicProgram,
                    CycleId = item.Schedule.CycleId,
                    Cycle = item.Schedule.Cycle,
                    TimeScheduleIn = item.Schedule.TimeScheduleIn,
                    TimeScheduleOut = item.Schedule.TimeScheduleOut,
                    MaxStudent = item.Schedule.MaxStudent,
                    MinStudent = item.Schedule.MinStudent
                },
                GradingPeriods = item.GradeBookItems
                    .Select(gbi => gbi.GradingPeriod)
                    .Distinct()
                    .Select(gp => new
                    {
                        Id = gp.Id,
                        GradingPeriodDescription = gp.GradingPeriodDescription,
                        GradingNumber = gp.GradingNumber,
                        GradeBookItems = item.GradeBookItems
                            .Where(gbi => gbi.GradingPeriodId == gp.Id)
                            .Select(gbi => new
                            {
                                Id = gbi.Id,
                                ItemName = gbi.ItemName,
                                Weight = gbi.Weight,
                                GradingPeriodId = gbi.GradingPeriodId,
                                GradeBookItemDetails = gbi.GradeBookItemDetails // Access directly from the `gbi`
                                    .Select(gbid => new
                                    {
                                        Id = gbid.Id,
                                        ItemDetail = gbid.ItemDetail,
                                        ItemDetailDescription = gbid.ItemDetailDescription,
                                        MaxScore = gbid.MaxScore,
                                        PassingScore = gbid.PassingScore,
                                        Weight = gbid.Weight,
                                        // Fk
                                        GradeBookItemId = gbid.GradeBookItemId,
                                        GradeBookItem = (GradeBookItem?) null,
                                        // Fk
                                        EqaAssessmentTypeId = gbid.EqaAssessmentTypeId,
                                        EqaAssessmentType = gbid.EqaAssessmentType,
                                    }).ToList()
                            }).ToList()
                    }).ToList()  // Ensure `.ToList()` is added here
            };

    }

    public async new Task<ICollection<GetGradeBookDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetGradeBookDto>>(await _dbModel
            .Include(gb => gb.Schedule)
            .ToListAsync());
    }

    public async new Task<GetGradeBookDto?> GetAsync(int id)
    {
        return _mapper.Map<GetGradeBookDto?>(await _dbModel
            .Include(gb => gb.Schedule)
            .Where(gb => gb.Id == id)
            .FirstOrDefaultAsync());
    }

    public async new Task<bool> CreateAsync(GradeBook newItem)
    {
        await _dbModel.AddAsync(newItem);
        var result = await Save();
        if (result)
        {
            newItem.Schedule = await _dbContext.Schedules.FindAsync(newItem.ScheduleId);
        }
        return result;
    }

    public async new Task<bool> UpdateSync(GradeBook updatedItem)
    {
        _dbModel.Update(updatedItem);
        var result = await Save();
        if (result)
        {
            updatedItem.Schedule = await _dbContext.Schedules.FindAsync(updatedItem.ScheduleId);
        }
        return result;
    }
}
