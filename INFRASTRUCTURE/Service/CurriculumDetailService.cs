
using APPLICATION.Dto.CurriculumDetail;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class CurriculumDetailService:GenericService<CurriculumDetail, GetCurriculumDetailDto>, ICurriculumDetailService
{
    public CurriculumDetailService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> GetInfoByCurriculumId(int curriculumId)
    {
        var items = _dbModel
            .Include(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicTerm)
            .Include(cd => cd.Course)
                .ThenInclude(course => course.CourseRequisites)
            .Where(cd => cd.CurriculumId == curriculumId);

        return await items.GroupBy(cd => cd.YearLevel)
            .Select(yearLevels => new
            {
                AcademicProgramId = yearLevels.First().Curriculum.AcademicProgramId,
                AcademicProgramName = yearLevels.First().Curriculum.AcademicProgram.ProgramName,

                YearLevel = $"{Utility.AddSuffix(int.Parse(yearLevels.Key.ToString()))} Year",
                Terms = yearLevels
                    .GroupBy(curriculumDetail => curriculumDetail.TermNumber)
                    .Select(curriculumDetail => new 
                    { 
                        TermName = Utility.AddSuffix(int.Parse(curriculumDetail.Key.ToString())) + " " + curriculumDetail.First().Curriculum.AcademicTerm.Label,
                        TermNumber = curriculumDetail.Key,
                        Courses = curriculumDetail
                            .Select(c => new
                            {
                                CurriculumDetailsId = c.Id,
                                CourseId = c.CourseId,
                                CourseTitle = c.Course.CourseTitle,
                                CourseCode = c.Course.CourseCode,
                                CourseDescription = c.Course.CourseDescription,
                                LectureUnits = c.Course.LectureUnits,
                                LaboratoryUnits = c.Course.LaboratoryUnits,
                                CreditUnits = c.Course.CreditUnits,
                                PreRequisites = c.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.PreRequisite).Select(cr => new
                                {
                                    CourseId = cr.RequisiteCourse.Id,
                                    CourseCode = cr.RequisiteCourse.CourseCode,
                                    CourseDescription = cr.RequisiteCourse.CourseDescription
                                }),
                                CoRequisites = c.Course.CourseRequisites
                                .Where(cr => cr.Type == CourseRequisiteType.CoRequisite).Select(cr => new
                                {
                                    CourseId = cr.RequisiteCourse.Id,
                                    CourseCode = cr.RequisiteCourse.CourseCode,
                                    CourseDescription = cr.RequisiteCourse.CourseDescription
                                }),
                                Equivalents = c.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.Equivalent).Select(cr => new
                                {
                                    CourseId = cr.RequisiteCourse.Id,
                                    CourseCode = cr.RequisiteCourse.CourseCode,
                                    CourseDescription = cr.RequisiteCourse.CourseDescription
                                })
                            })
                    })
            }).ToListAsync();
    }

    public async Task<ICollection<GetCurriculumDetailDto>> GetCurriculumDetailsByCourseId(int courseId)
    {
        return _mapper.Map<ICollection<GetCurriculumDetailDto>>(await _dbModel
            .Include(cd => cd.Curriculum)
            .Where(cd => cd.CourseId == courseId)
            .ToListAsync());
    }

    public async new Task<GetCurriculumDetailDto?> CreateAsync(CurriculumDetail newItem) {
        var courseCoRequisites = _dbContext
                .Courses
                .Include(c => c.CourseRequisites)
                    .ThenInclude(c => c.RequisiteCourse)
                .Where(c => c.Id == newItem.CourseId)
                .AsNoTracking()
                .ToList()
                .SelectMany(c => c.CourseRequisites)
                .Where(cr => cr.Type == CourseRequisiteType.CoRequisite)
                .Select(cr => cr.RequisiteCourse)
                .Select(cr => new CurriculumDetail {
                    CourseId = cr.Id,
                    CurriculumId = newItem.CurriculumId,
                    IsIncludeGWA = newItem.IsIncludeGWA,
                    YearLevel = newItem.YearLevel,
                    TermNumber = newItem.TermNumber
                })
                .ToList();
        courseCoRequisites.Add(newItem);
        await _dbModel.AddRangeAsync(courseCoRequisites);
        if (await Save()) {
            return _mapper.Map<GetCurriculumDetailDto>(newItem);
        }
        return null;
    }

    public async Task<object?> CreateCurriculumDetailGroupedByCourse(CurriculumDetailGroup curriculumDetailGroup)
    {
        var curriculumDetails = curriculumDetailGroup.CourseId.Select(courseId => {
               
            var courseRequisites = _dbContext
                .Courses
                .Include(c => c.CourseRequisites)
                    .ThenInclude(c => c.RequisiteCourse)
                .Where(c => c.Id == courseId)
                .AsNoTracking()
                .ToList()
                .SelectMany(c => c.CourseRequisites)
                .Where(cr => cr.Type == CourseRequisiteType.CoRequisite)
                .Select(cr => cr.RequisiteCourse)
                .Select(cr => new CurriculumDetail {
                    CourseId = cr.Id,
                    CurriculumId = curriculumDetailGroup.CurriculumId,
                    IsIncludeGWA = curriculumDetailGroup.IsIncludeGWA,
                    YearLevel = curriculumDetailGroup.YearLevel,
                    TermNumber = curriculumDetailGroup.TermNumber
                })
                .ToList();

            courseRequisites.Add(new CurriculumDetail {
                CurriculumId = curriculumDetailGroup.CurriculumId,
                IsIncludeGWA = curriculumDetailGroup.IsIncludeGWA,
                YearLevel = curriculumDetailGroup.YearLevel,
                TermNumber = curriculumDetailGroup.TermNumber,
                CourseId = courseId,
            });

            return courseRequisites;

        })
        .SelectMany(c => c)
        .ToList();

        var result = await CreateAllAsync(curriculumDetails);
        return (result != null)
            ? curriculumDetails.Select(cd => 
                _dbModel
                    .Include(cd2 => cd2.Course)
                        .ThenInclude(cd2 => cd2.CourseRequisites)
                    .Include(cd2 => cd2.Curriculum)
                        .ThenInclude(cd2 => cd2.AcademicProgram)
                    .Include(cd2 => cd2.Curriculum)
                        .ThenInclude(cd2 => cd2.AcademicTerm)
                    .Where(cd2 => cd2.Id == cd.Id)
                    .Select(cd2 => new
                    {
                        Id = cd2.Id,
                        YearLevel = $"{Utility.AddSuffix(int.Parse(cd2.YearLevel.ToString()))} Year",
                        TermNumber = $"{Utility.AddSuffix(int.Parse(cd2.TermNumber.ToString()))} {cd2.Curriculum.AcademicTerm.Label}",
                        IsIncludeGWA = cd2.IsIncludeGWA,
                        CurriculumId = cd2.CurriculumId,
                        Curriculum = cd2.Curriculum,
                        CourseId = cd2.CourseId,
                        Course = new
                        {
                            Id = cd2.Course.Id,
                            CourseCode = cd2.Course.CourseCode,
                            CourseDescription = cd2.Course.CourseDescription,
                            LectureUnits = cd2.Course.LectureUnits,
                            LaboratoryUnits = cd2.Course.LaboratoryUnits,
                            CreditUnits = cd2.Course.CreditUnits,
                            PreRequisites = cd2.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.PreRequisite).Select(cr => new Course
                            {
                                Id = cr.Course.Id,
                                CourseCode = cr.Course.CourseCode,
                                CourseDescription = cr.Course.CourseDescription
                            }).ToList(),
                            CoRequisites = cd2.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.CoRequisite).Select(cr => new Course
                            {
                                Id = cr.Course.Id,
                                CourseCode = cr.Course.CourseCode,
                                CourseDescription = cr.Course.CourseDescription
                            }).ToList(),
                            Equivalents = cd2.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.Equivalent).Select(cr => new Course
                            {
                                Id = cr.Course.Id,
                                CourseCode = cr.Course.CourseCode,
                                CourseDescription = cr.Course.CourseDescription
                            }).ToList()
                        }
                    })
                    .FirstOrDefault()
            )
            : null;
    }

    public async new Task<bool> DeleteSync(CurriculumDetail oldItem) {
        var courseRequisites = _dbContext
            .Courses
            .Include(c => c.CourseRequisites)
                .ThenInclude(c => c.RequisiteCourse)
            .Where(c => c.Id == oldItem.CourseId)
            .AsNoTracking()
            .ToList()
            .SelectMany(c => c.CourseRequisites)
            .Where(cr => cr.Type == CourseRequisiteType.CoRequisite)
            .Select(cr => cr.RequisiteCourse)
            .Where(cr => _dbModel
                    .Where(cd => cd.CurriculumId == oldItem.CurriculumId)
                    .Where(cd => cd.TermNumber == oldItem.TermNumber)
                    .Where(cd => cd.YearLevel == oldItem.YearLevel)
                    .Where(cd => cd.CourseId == cr.Id).Any())
            .Select(cr => {
                var match = _dbModel
                    .Where(cd => cd.CurriculumId == oldItem.CurriculumId)
                    .Where(cd => cd.TermNumber == oldItem.TermNumber)
                    .Where(cd => cd.YearLevel == oldItem.YearLevel)
                    .Where(cd => cd.CourseId == cr.Id)
                    .AsNoTracking()
                    .FirstOrDefault();
                return new CurriculumDetail {
                    Id = match.Id,
                    CourseId = cr.Id,
                    CurriculumId = match.CurriculumId,
                    IsIncludeGWA = match.IsIncludeGWA,
                    YearLevel = match.YearLevel,
                    TermNumber = match.TermNumber
                };
            })
            .ToList();
        if (!courseRequisites.Where(cr => cr.Id == oldItem.Id).Any()) {
            courseRequisites.Add(oldItem);
        }
        _dbModel.RemoveRange(courseRequisites);
        return await Save();
    }
}
