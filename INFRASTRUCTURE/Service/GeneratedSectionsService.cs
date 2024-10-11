
using APPLICATION.Dto.GeneratedSections;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace INFRASTRUCTURE.Service;
public class GeneratedSectionsService:GenericService<GeneratedSections, GetGeneratedSectionsDto>, IGeneratedSectionsService
{
    public GeneratedSectionsService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetGeneratedSectionsDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetGeneratedSectionsDto>>(await _dbModel
            .Include(gs => gs.Cycle)
            .Include(gs => gs.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .ToListAsync());
    }

    public async Task<ICollection<GetGeneratedSectionsDto>> GetGeneratedSectionByCurriculumCycleIdAndYearLevel(int curriculumId, int cycleId, int yearLevel)
    {
        return _mapper.Map<ICollection<GetGeneratedSectionsDto>>(await _dbModel
            .Include(g => g.Cycle)
            .Include(g => g.CurriculumDetail)
                .ThenInclude(cd => cd.Curriculum)
            .Include(g => g.CurriculumDetail)
                .ThenInclude(cd => cd.Course)
            .Where(g => g.CurriculumDetail.CurriculumId == curriculumId && g.CycleId == cycleId && g.CurriculumDetail.YearLevel == yearLevel)
            .ToListAsync());
    }

    public async Task<object?> GenerateSections(int numberOfSection, GenerateSectionGroupDto section)
    {
        if (numberOfSection <= 0 || section.CurriculumDetailsId.Length <= 0)
        {
            return null;
        }

        List<GeneratedSectionsDto> preGenerated = new List<GeneratedSectionsDto>();

        var lastInsertedId = _dbModel
            .OrderByDescending(s => s.Id)
            .Select(s => s.Id)
            .FirstOrDefault();

        foreach (var sched in section.CurriculumDetailsId)
        {
            int alreadyInserted = 0;

            // Fetch curriculum details only once for the current schedule
            var curriculumDetails = _dbContext.CurriculumDetails
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicProgram)
                        .ThenInclude(ap => ap.College)
                            .ThenInclude(c => c.Campus)
                .Include(curr => curr.Curriculum)
                    .ThenInclude(curr => curr.AcademicTerm)
                .FirstOrDefault(cd => cd.Id == sched);

            if (curriculumDetails == null) continue;

            alreadyInserted += _dbModel
                .Include(s => s.CurriculumDetail)
                    .ThenInclude(s => s.Curriculum)
                        .ThenInclude(s => s.AcademicProgram)
                .Count(s => s.CycleId == section.CycleId && s.CurriculumDetail.Curriculum.AcademicProgramId == curriculumDetails.Curriculum.AcademicProgramId);

            // Generate schedules
            for (var i = 0; i < numberOfSection; i++)
            {
                // Generate suffix
                char suffix = (char)('A' + (alreadyInserted + i) % 26);
                int numberPart = (alreadyInserted + i) / 26;
                var suffix2 = numberPart > 0 ? numberPart.ToString() : "";

                var referenceBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(curriculumDetails.Curriculum.AcademicProgram.College.Campus.CampusShortName)
                    .Append('_')
                    .Append(PrefixAZero(section.CycleId))
                    .Append('_')
                    .Append(lastInsertedId + (preGenerated.Count + 1));

                var sectionBuilder = new StringBuilder()
                    .Append(curriculumDetails.Curriculum.CurriculumCode)
                    .Append('_')
                    .Append(suffix)
                    .Append(suffix2);

                preGenerated.Add(new GeneratedSectionsDto
                {
                    CurriculumDetailId = sched,
                    CycleId = section.CycleId,
                    SectionCode = referenceBuilder.ToString(),
                    SectionName = sectionBuilder.ToString(),
                });
            }
        }

        if ((numberOfSection * section.CurriculumDetailsId.Length) != preGenerated.Count)
        {
            return null;
        }

        var items = _mapper.Map<ICollection<GeneratedSections>>(preGenerated);

        var result = await CreateAllAsync(items.ToArray());
        if (result)
        {
            foreach (var item in items)
            {
                item.Cycle = _dbContext.Cycles.Find(item.CycleId);
                item.CurriculumDetail = _dbContext.CurriculumDetails
                        .Include(cd => cd.Course)
                        .Where(cd => cd.Id == item.CurriculumDetailId)
                        .FirstOrDefault();
            }
        }

        return result
            ? _mapper.Map<ICollection<GetGeneratedSectionsDto>>(items)
            : null;
    }

    public string PrefixAZero(int id)
    {
        int numberOfDigits = 6;
        return id.ToString().PadLeft(numberOfDigits, '0');
    }
}
