using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.GradeBook;
using APPLICATION.IService.GradeBookData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using INFRASTRUCTURE.ErrorHandler;

namespace INFRASTRUCTURE.Service.GradeBookData;

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
            throw new Error400("GradeBook already exists for this Schedule");
        }

        var templateGradeBook = _dbContext.TemplateGradeBooks
                .Include(tgb => tgb.TemplateGradeBookItems)
                    .ThenInclude(tgbi => tgbi.TemplateGradeBookItemDetails)
                        .ThenInclude(tgbid => tgbid.EqaAssessmentType)
                .Where(tgb => tgb.Id == templateGradeBookId)
                .FirstOrDefault();
        
        if (templateGradeBook == null)
        {
            throw new Error404("GradeBook Template not found");
        }

        var gradeBook = new GradeBook
        {
            GradeBookDescription = templateGradeBook.TemplateName,
            ScheduleId = scheduleId
        };

        if ((await CreateAsync(gradeBook) == null))
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
           throw new Error400("GradeBook Items not saved");
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
                    AcademicProgramId = gradeBook.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
                    AcademicProgram = gradeBook.Schedule.CurriculumDetail.Curriculum.AcademicProgram,
                    CourseId = gradeBook.Schedule.CurriculumDetail.CourseId,
                    Course = gradeBook.Schedule.CurriculumDetail.Course,
                    CycleId = gradeBook.Schedule.CycleId,
                    Cycle = gradeBook.Schedule.Cycle,
                    IsExclusive = gradeBook.Schedule.IsExclusive,
                    IsPetitionSchedule = gradeBook.Schedule.IsPetitionSchedule,
                    MaxStudent = gradeBook.Schedule.MaxStudent,
                    MinStudent = gradeBook.Schedule.MinStudent
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
        var item = await _dbModel
        .Include(gb => gb.Schedule)
            .ThenInclude(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
        .Include(gb => gb.Schedule)
            .ThenInclude(s => s.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
                    .ThenInclude(c => c.AcademicProgram)
        .Include(gb => gb.GradeBookItems)
             .ThenInclude(gbi => gbi.GradingPeriod)
        .Include(gb => gb.GradeBookItems)
            .ThenInclude(gbi => gbi.GradeBookItemDetails)
                .ThenInclude(gbid => gbid.EqaAssessmentType)
        .Where(gb => gb.ScheduleId == scheduleId)
        .FirstOrDefaultAsync();

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
                    CourseId = item.Schedule.CurriculumDetail.CourseId,
                    Course = item.Schedule.CurriculumDetail.Course,  // Changed this to directly use the course from the included navigation property
                    AcademicProgramId = item.Schedule.CurriculumDetail.Curriculum.AcademicProgramId,
                    AcademicProgram = item.Schedule.CurriculumDetail.Curriculum.AcademicProgram,
                    CycleId = item.Schedule.CycleId,
                    Cycle = item.Schedule.Cycle,
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
        var gradeBooks = await _dbModel
        .Include(gb => gb.Schedule)
        .ToListAsync();
        return _mapper.Map<ICollection<GetGradeBookDto>>(gradeBooks);
    }

    public async new Task<GradeBook?> GetAsync(int id)
    {
        var gradeBook = await _dbModel
        .Include(gb => gb.Schedule)
        .Where(gb => gb.Id == id)
        .AsNoTracking()
        .SingleOrDefaultAsync();
        return gradeBook;
    }

    public async new Task<GetGradeBookDto?> CreateAsync(GradeBook newItem)
    {
        await _dbModel.AddAsync(newItem);
        if (await Save())
        {
            newItem.Schedule = await _dbContext.Schedules
                .Include(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
                .Include(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Curriculum)
                        .ThenInclude(c => c.AcademicProgram)
                .Where(s => s.Id == newItem.ScheduleId)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetGradeBookDto>(newItem);
        }
        return null;
    }

    public async new Task<GetGradeBookDto?> UpdateAsync(GradeBook updatedItem)
    {
        _dbModel.Update(updatedItem);
        if (await Save())
        {
            updatedItem.Schedule = await _dbContext
                .Schedules
                .Include(s => s.CurriculumDetail)
                    .ThenInclude(cd => cd.Course)
                .Where(s => s.Id == updatedItem.ScheduleId)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetGradeBookDto>(updatedItem);
        }
        return null;
    }
}
