using APPLICATION.Dto.Instrument;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class InstrumentService:GenericService<Instrument, GetInstrumentDto>, IInstrumentService
{
    public InstrumentService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async new Task<ICollection<GetInstrumentDto>> GetAllAsync()
    {
        var result = await _dbModel
            .Include(i => i.ParameterCategories)
                .ThenInclude(pc => pc.ParameterSubCategories)
                    .ThenInclude(psc => psc.Parameters)
                        .ThenInclude(p => p.LikertQuestions)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<ICollection<GetInstrumentDto>>(result);
    }

    public async new Task<Instrument?> GetAsync(int id)
    {
        var result = await _dbModel
            .Include(i => i.ParameterCategories)
                .ThenInclude(pc => pc.ParameterSubCategories)
                    .ThenInclude(psc => psc.Parameters)
                        .ThenInclude(p => p.LikertQuestions)
            .AsNoTracking()
            .SingleOrDefaultAsync(i => i.Id == id);
        return result;
    }

    public async Task<object?> GetInstrumentInfo(int id)
    {
        var instrument = await _dbModel
            .Include(i => i.ParameterCategories)
                .ThenInclude(pc => pc.ParameterSubCategories)
                    .ThenInclude(psc => psc.Parameters)
                        .ThenInclude(p => p.LikertQuestions)
            .Where(i => i.Id == id)
            .SingleOrDefaultAsync();
        if (instrument == null)
        {
            return null;
        }
        return new
        {
            Id = instrument.Id,
            Name = instrument.Name,
            Description = instrument.Description,
            NumberOfChoices = instrument.NumberOfChoices,
            IsEnabled = instrument.IsEnabled,
            ParameterSubCategories = instrument.ParameterCategories.Select(pc => new
            {
                Id = pc.Id,
                ParameterCategoryName = pc.ParameterCategoryName,
                ParameterSubCategories = pc.ParameterSubCategories.Select(psc => new
                {
                    Id = psc.Id,
                    ParameterSubCategoryName = psc.ParameterSubCategoryName,
                    Parameters = psc.Parameters.Where(p => p.ParentId == null).Select(p => new
                    {
                        Id = p.Id,
                        ParameterName = p.ParameterName,
                        QuestionTypeLikertOrText = p.QuestionTypeLikertOrText,
                        ParentId = p.ParentId,
                        Children = psc.Parameters.Where(p => p.ParentId != null)
                            .Select(c => new
                            {
                                Id = c.Id,
                                ParameterName = c.ParameterName,
                                QuestionTypeLikertOrText = c.QuestionTypeLikertOrText,
                                ParentId = c.ParentId,
                                LikertQuestions = c.LikertQuestions.Select(lq => new
                                {
                                    Id = lq.Id,
                                    QuestionText = lq.QuestionText,
                                    LikertScale = lq.LikertScale,
                                    IsEnabled = lq.IsEnabled,
                                    IsVisible = lq.IsVisible,
                                    ParameterId = lq.ParameterId
                                }).ToList()
                            }).ToList(),
                        LikertQuestions = p.LikertQuestions.Select(lq => new
                        {
                            Id = lq.Id,
                            QuestionText = lq.QuestionText,
                            LikertScale = lq.LikertScale,
                            IsEnabled = lq.IsEnabled,
                            IsVisible = lq.IsVisible,
                            ParameterId = lq.ParameterId
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToList()
        };
    }

    public async Task<object?> CreateInstrumentByGroup(InstrumentGroupDto group)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                // Step 1: Create and save the Instrument to generate the Id
                var instrument = new Instrument
                {
                    Name = group.Name,
                    Description = group.Description,
                    NumberOfChoices = group.NumberOfChoices,
                    IsEnabled = group.IsEnabled
                };

                if ((await CreateAsync(instrument)) == null) return null;

                // Step 2: Prepare and save Parameter Categories
                var parameterCategories = group.ParameterCategories.Select(pc => new ParameterCategory
                {
                    ParameterCategoryName = pc.ParameterCategoryName,
                    InstrumentId = instrument.Id
                }).ToList();

                _dbContext.ParameterCategories.AddRange(parameterCategories);
                if (!await Save()) return null;

                // Step 3: Prepare Parameter SubCategories with assigned ParameterCategoryId
                var parameterSubCategories = group.ParameterCategories.SelectMany((pc, i) => pc.ParameterSubCategories.Select(psc => new ParameterSubCategory
                {
                    ParameterSubCategoryName = psc.ParameterSubCategoryName,
                    ParameterCategoryId = parameterCategories[i].Id
                })).ToList();

                await _dbContext.ParameterSubCategories.AddRangeAsync(parameterSubCategories);
                if (!await Save()) return null;

                // Step 4: Prepare Parameters with correct ParameterSubCategoryId
                var parameters = group.ParameterCategories.SelectMany((pc, i) =>
                    pc.ParameterSubCategories.SelectMany(psc =>
                        psc.ParameterGroups.Select(p => new Parameter
                        {
                            ParameterName = p.ParameterName,
                            QuestionTypeLikertOrText = p.QuestionTypeLikertOrText,
                            ParentId = p.ParentId,
                            ParameterSubCategoryId = parameterSubCategories
                                .First(sub => sub.ParameterSubCategoryName == psc.ParameterSubCategoryName && sub.ParameterCategoryId == parameterCategories[i].Id).Id
                        })
                    )
                ).ToList();

                await _dbContext.Parameters.AddRangeAsync(parameters);
                if (!await Save()) return null;

                // Step 5: Prepare LikertQuestions with correct ParameterId
                var likertQuestions = group.ParameterCategories.SelectMany((pc, i) =>
                    pc.ParameterSubCategories.SelectMany(psc =>
                        psc.ParameterGroups.SelectMany(p =>
                            p.likertQuestions.Select(lq => new LikertQuestion
                            {
                                QuestionText = lq.QuestionText,
                                IsVisible = lq.IsVisible,
                                LikertScale = lq.LikertScale,
                                IsEnabled = lq.IsEnabled,
                                ParameterId = parameters.First(param => param.ParameterName == p.ParameterName && param.ParameterSubCategoryId ==
                                    parameterSubCategories.First(sub => sub.ParameterSubCategoryName == psc.ParameterSubCategoryName && sub.ParameterCategoryId == parameterCategories[i].Id).Id).Id
                            })
                        )
                    )
                ).ToList();

                await _dbContext.LikertQuestions.AddRangeAsync(likertQuestions);
                if (!await Save()) return null;

                // Commit the transaction
                await transaction.CommitAsync();

                // Build and return the hierarchical DTO structure
                var instrumentDto = new
                {
                    Id = instrument.Id,
                    Name = instrument.Name,
                    Description = instrument.Description,
                    NumberOfChoices = instrument.NumberOfChoices,
                    IsEnabled = instrument.IsEnabled,
                    ParameterCategories = parameterCategories.Select(pc => new
                    {
                        Id = pc.Id,
                        ParameterCategoryName = pc.ParameterCategoryName,
                        ParameterSubCategories = parameterSubCategories
                            .Where(psc => psc.ParameterCategoryId == pc.Id)
                            .Select(psc => new
                            {
                                Id = psc.Id,
                                ParameterSubCategoryName = psc.ParameterSubCategoryName,
                                Parameters = parameters
                                    .Where(p => p.ParameterSubCategoryId == psc.Id)
                                    .Select(p => new
                                    {
                                        Id = p.Id,
                                        ParameterName = p.ParameterName,
                                        ParentId = p.ParentId,
                                        LikertQuestions = likertQuestions
                                            .Where(lq => lq.ParameterId == p.Id)
                                            .Select(lq => new
                                            {
                                                Id = lq.Id,
                                                QuestionText = lq.QuestionText,
                                                LikertScale = lq.LikertScale,
                                                IsEnabled = lq.IsEnabled,
                                                IsVisible = lq.IsVisible,
                                                ParameterId = lq.ParameterId
                                            }).ToList()
                                    }).ToList()
                            }).ToList()
                    }).ToList()
                };

                return instrumentDto;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
