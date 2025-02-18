using AutoMapper;
using Microsoft.EntityFrameworkCore;
using APPLICATION.Dto.SkillsFrameworkTrackSpecialization;
using APPLICATION.Dto.SpecializationChair;
using APPLICATION.IService.DesignationData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.DesignationData;

public class SpecializationChairService:GenericService<SpecializationChair, GetSpecializationChairDto>, ISpecializationChairService
{
    public SpecializationChairService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<bool> IsSpecializationChair(string userId)
    {
        return await _dbModel.Where(sc => sc.UserId == userId).AnyAsync();
    }

    public async Task<GetSkillsFrameworkTrackSpecializationDto> GetTrackSpecializationByUserId(string userId)
    {
        return await _dbModel
            .Include(x => x.SFTrackSpecialization)
            .Where(x => x.UserId == userId)
            .Select(x => _mapper.Map<GetSkillsFrameworkTrackSpecializationDto>(x.SFTrackSpecialization))
            .SingleOrDefaultAsync();
    }

    public async new Task<ICollection<GetSpecializationChairDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<GetSpecializationChairDto>>(await _dbModel
            .Include(sf => sf.SFTrackSpecialization)
            .Include(sf => sf.User)
            .ToListAsync());
    }

    public async Task<object> GetAllPendingCourseCrediting(string userId, int trackSpecializationId)
    {
        var result = await _dbContext.CourseCreditings
            .Include(x => x.Course)
                .Where(x => x.Course.SfTrackSpecializationId == trackSpecializationId)
                .Where(cc => cc.EvaluatedByUserId == null)
                .Where(cc => cc.Status == GlobalValidityStatusEnum.PENDING || cc.Status == GlobalValidityStatusEnum.RETURNED)
                .AsNoTracking()
                .ToListAsync();
        return result;
    }

    public async Task<object> GetAllApprovedCourseCrediting(string userId, int trackSpecializationId)
    {
        var result = await _dbContext.CourseCreditings
            .Include(x => x.Course)
                .Where(x => x.Course.SfTrackSpecializationId == trackSpecializationId)
                .Where(cc => cc.EvaluatedByUserId == userId)
                .Where(cc => cc.Status == GlobalValidityStatusEnum.APPROVED)
                .AsNoTracking()
                .ToListAsync();
        return result;
    }

    public async Task<object> GetAllRejectedCourseCrediting(string userId, int trackSpecializationId)
    {
        var result = await _dbContext.CourseCreditings
            .Include(x => x.Course)
                .Where(x => x.Course.SfTrackSpecializationId == trackSpecializationId)
                .Where(cc => cc.EvaluatedByUserId == userId)
                .Where(cc => cc.Status == GlobalValidityStatusEnum.REJECTED)
                .AsNoTracking()
                .ToListAsync();
        return result;
    }

    public async Task<object> GetAllReturnedCourseCrediting(string userId, int trackSpecializationId)
    {
        var result = await _dbContext.CourseCreditings
            .Include(x => x.Course)
                .Where(x => x.Course.SfTrackSpecializationId == trackSpecializationId)
                .Where(cc => cc.EvaluatedByUserId == null)
                .Where(cc => cc.Status == GlobalValidityStatusEnum.RETURNED)
                .AsNoTracking()
                .ToListAsync();
        return result;
    }

    public async Task<object> GetAllCurriculumBySfTrackSpecialization(int trackSpecializationId)
    {
        // Get All Course
        var courseCreditings = await _dbContext.CourseCreditings
            .Include(x => x.Course)
                .Where(x => x.Course.SfTrackSpecializationId == trackSpecializationId)
                .AsNoTracking()
                .ToListAsync();

        var curriculums = await _dbContext.CurriculumDetails
            .Include(cd => cd.Curriculum)
                .ThenInclude(c => c.AcademicProgram)
            .Include(cd => cd.Curriculum)
                .ThenInclude(cd => cd.AcademicTerm)
            .Where(cd => courseCreditings.Select(cc => cc.CourseId).Contains(cd.CourseId))
            .Select(cd => cd.Curriculum)
            .Distinct()
            .ToListAsync();

        return curriculums.Select(c => new
        {
            Id = c.AcademicProgram.Id,
            ProgramName = c.AcademicProgram.ProgramName,
            ShortName = c.AcademicProgram.ShortName,
            CollegeId = c.AcademicProgram.CollegeId,
            Curriculums = curriculums.Where(curr => curr.AcademicProgramId == c.AcademicProgram.Id)
                .Select(curr => new
                {
                    Id = curr.Id,
                    CurriculumName = curr.CurriculumName,
                    CurriculumCode = curr.CurriculumCode,
                    AcademicProgramId = curr.AcademicProgramId,
                    AcademicTermId = curr.AcademicTermId,
                    AcademicTerm = curr.AcademicTerm,
                    Major = curr.Major,
                    Minor = curr.Minor,
                    AuthorityLegal = curr.AuthorityLegal,
                    IsDefault = curr.IsDefault,
                }).ToList()
        }).ToList();
    }
}
