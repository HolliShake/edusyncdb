
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

        return items.GroupBy(cd => cd.YearLevel)
            .Select(yearLevels => new
            {
                AcademicProgramId = yearLevels.First().Curriculum.AcademicProgramId,
                AcademicProgramName = yearLevels.First().Curriculum.AcademicProgram.ProgramName,

                YearLevel = $"{AddSuffix(int.Parse(yearLevels.Key.ToString()))} Year",
                Terms = yearLevels
                    .GroupBy(curriculumDetail => curriculumDetail.TermNumber)
                    .Select(curriculumDetail => new 
                    { 
                        TermName = AddSuffix(int.Parse(curriculumDetail.Key.ToString())) + " " + curriculumDetail.First().Curriculum.AcademicTerm.Label,
                        TermNumber = curriculumDetail.Key,
                        Courses = curriculumDetail
                            .Select(c => new
                            {
                                CurriculumDetailsId = c.Id,
                                CourseId = c.CourseId,
                                CouseCode = c.Course.CourseCode,
                                CourseDescription = c.Course.CourseDescription,
                                LectureUnits = c.Course.LectureUnits,
                                LaboratoryUnits = c.Course.LaboratoryUnits,
                                CreditUnits = c.Course.CreditUnits,
                                PreRequisites = c.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.PreRequisite).Select(cr => new
                                {
                                    CourseId = cr.CourseId,
                                    CourseCode = cr.Course.CourseCode,
                                    CourseDescription = cr.Course.CourseDescription
                                }),
                                CoRequisites = c.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.CoRequisite).Select(cr => new
                                {
                                    CourseId = cr.CourseId,
                                    CourseCode = cr.Course.CourseCode,
                                    CourseDescription = cr.Course.CourseDescription
                                }),
                                Equivalents = c.Course.CourseRequisites.Where(cr => cr.Type == CourseRequisiteType.Equivalent).Select(cr => new
                                {
                                    CourseId = cr.CourseId,
                                    CourseCode = cr.Course.CourseCode,
                                    CourseDescription = cr.Course.CourseDescription
                                })
                            })
                    })
            });
    }

    static string AddSuffix(int number)
    {
        if (number <= 0) return number.ToString();

        // Get the last digit of the number
        int lastDigit = number % 10;

        // Determine the suffix
        string suffix = "th"; // Default suffix

        if (number % 100 is < 11 or > 13) // Handle the exceptions for 11th, 12th, and 13th
        {
            suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }

        return $"{number}{suffix}";
    }

    private IQueryable<int> GenerateTerms(int number_of_terms)
    {
        List<int> items = [];
        for (var i = 1; i <= number_of_terms; i++)
        {
            items.Add(i);
        }
        return items.AsQueryable();
    }

    public async Task<ICollection<GetCurriculumDetailDto>> GetCurriculumDetailsByCourseId(int courseId)
    {
        return _mapper.Map<ICollection<GetCurriculumDetailDto>>(await _dbModel
            .Include(cd => cd.Curriculum)
            .Where(cd => cd.CourseId == courseId)
            .ToListAsync());
    }

    public async Task<object?> CreateCurriculumDetailGroupedByCourse(CurriculumDetailGroup curriculumDetailGroup)
    {
        var curriculumDetails = curriculumDetailGroup.CourseId.Select(courseId => new CurriculumDetail
        {
            CurriculumId = curriculumDetailGroup.CurriculumId,
            IsIncludeGWA = curriculumDetailGroup.IsIncludeGWA,
            YearLevel = curriculumDetailGroup.YearLevel,
            TermNumber = curriculumDetailGroup.TermNumber,
            CourseId = courseId,
        }).ToList();

        var result = await CreateAllAsync(curriculumDetails);
        return (result)
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
                        YearLevel = $"{AddSuffix(int.Parse(cd2.YearLevel.ToString()))} Year",
                        TermNumber = $"{AddSuffix(int.Parse(cd2.TermNumber.ToString()))} {cd2.Curriculum.AcademicTerm.Label}",
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
}
