
using APPLICATION.Dto.TemplateGradeBook;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class TemplateGradeBookService:GenericService<TemplateGradeBook, GetTemplateGradeBookDto>, ITemplateGradeBookService
{
    public TemplateGradeBookService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object> GetAllAsStructuredAsync()
    {
        var items = await _dbModel
            .Include(tgb => tgb.TemplateGradeBookItems)
                .ThenInclude(tgbi => tgbi.TemplateGradeBookItemDetails)
                    .ThenInclude(tgbid => tgbid.EqaAssessmentType)
            .Include(tgb => tgb.TemplateGradeBookItems)
                .ThenInclude(tgb => tgb.GradingPeriod)
            .ToListAsync();

        return items.Select(tgb => new
        {
            Id = tgb.Id,
            TemplateName = tgb.TemplateName,
            GradingPeriods = tgb.TemplateGradeBookItems
                .Select(tgbi => tgbi.GradingPeriod)
                .Distinct()
                .Select(gp => new
                {
                    Id = gp.Id,
                    GradingPeriodDescription = gp.GradingPeriodDescription,
                    GradingNumber = gp.GradingNumber,
                    TemplateGradeBookItems = tgb.TemplateGradeBookItems
                        .Where(tgbi => tgbi.GradingPeriodId == gp.Id)
                        .Select(tgbi => new
                        {
                            Id = tgbi.Id,
                            ItemName = tgbi.ItemName,
                            Weight = tgbi.Weight,
                            GradingPeriodId = tgbi.GradingPeriodId,
                            TemplateGradeBookItemDetails = tgbi.TemplateGradeBookItemDetails
                                .Select(tgbid => new
                                {
                                    Id = tgbid.Id,
                                    ItemDetail = tgbid.ItemDetail,
                                    ItemDetailDescription = tgbid.ItemDetailDescription,
                                    MaxScore = tgbid.MaxScore,
                                    PassingScore = tgbid.PassingScore,
                                    Weight = tgbid.Weight,
                                    // Fk
                                    GradeBookItemId = tgbid.TemplateGradeBookItemId,
                                    GradeBookItem = (GradeBookItem?) null,
                                    // Fk
                                    EqaAssessmentTypeId = tgbid.EqaAssessmentTypeId,
                                    EqaAssessmentType = tgbid.EqaAssessmentType,
                                }),
                        }),
                }),
        });
    }

    public async Task<object?> TemplateGroupCreate(TemplateGradeBookGroupDto template)
    {
        var templateGradeBook = new TemplateGradeBook
        {
            TemplateName = template.TemplateName
        };

        if ((await CreateAsync(templateGradeBook)) == null)
        {
            return null;
        }

        var templateGradeBookItems = template.TemplateGradeBookItems.Select(t => new TemplateGradeBookItem
        {
            TemplateGradeBookId = templateGradeBook.Id,
            ItemName = t.ItemName,
            Weight = t.Weight,
            GradingPeriodId = t.GradingPeriodId,

        }).ToList();

        _dbContext.TemplateGradeBookItems.AddRange(templateGradeBookItems);
        var wasSaved = await Save();

        if (!wasSaved || (template.TemplateGradeBookItems.Length != templateGradeBookItems.Count()))
        {
            return null;
        }

        foreach (var item in templateGradeBookItems)
        {
            item.GradingPeriod = _dbContext.GradingPeriods.Find(item.GradingPeriodId);
        }

        List<TemplateGradeBookItemDetail> itemDetails = [];

        for (var i = 0;i < template.TemplateGradeBookItems.Length;i++)
        {
            var item = template.TemplateGradeBookItems[i];
            var savedItem = templateGradeBookItems[i];
            itemDetails.AddRange(item.TemplateGradeBookItemDetails.Select(d => new TemplateGradeBookItemDetail
            {
                TemplateGradeBookItemId = savedItem.Id,
                ItemDetail = d.ItemDetail,
                ItemDetailDescription = d.ItemDetailDescription,
                MaxScore = d.MaxScore,
                PassingScore = d.PassingScore,
                Weight = d.Weight,
                EqaAssessmentTypeId = d.EqaAssessmentTypeId,
            }));
        }

        _dbContext.TemplateGradeBookItemDetails.AddRange(itemDetails);
        var written = await Save();
        return (!written)
            ? null
            : new { 
            Id = templateGradeBook.Id,
            TemplateName = templateGradeBook.TemplateName,
            GradingPeriods = templateGradeBookItems
                .Select(t => t.GradingPeriod)
                .Distinct()
                .Select(gp => new
                {
                    Id = gp.Id,
                    GradingPeriodDescription = gp.GradingPeriodDescription,
                    GradingNumber = gp.GradingNumber,
                    TemplateGradeBookItems = templateGradeBookItems
                    .Where(t => t.GradingPeriodId == gp.Id)
                    .Select(t => new
                    {
                        Id = t.Id,
                        ItemName = t.ItemName,
                        Weight = t.Weight,
                        GradingPeriodId = t.GradingPeriodId,
                        TemplateGradeBookItemDetails = itemDetails.Where(d => d.TemplateGradeBookItemId == t.Id).Select(d => new
                        {
                            Id = d.Id,
                            ItemDetail = d.ItemDetail,
                            ItemDetailDescription = d.ItemDetailDescription,
                            MaxScore = d.MaxScore,
                            PassingScore = d.PassingScore,
                            Weight = d.Weight,
                            EqaAssessmentTypeId = d.EqaAssessmentTypeId,
                            EqaAssessmentType = _dbContext.EducationalQualityAssuranceAssessmentTypes.Find(d.EqaAssessmentTypeId),
                        }),
                    }),
                }),
        };
    }
}
