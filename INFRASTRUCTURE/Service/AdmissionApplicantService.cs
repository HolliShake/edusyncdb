
using APPLICATION.Dto.AdmissionApplicant;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class AdmissionApplicantService:GenericService<AdmissionApplicant, GetAdmissionApplicantDto>, IAdmissionApplicantService
{
    public AdmissionApplicantService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }

    public async Task<object?> ApplyApplication(AdmissionApplicantGroupedDto group)
    {
        var admissionApplicant = new AdmissionApplicant
        {
            FirstName = group.FirstName,
            MiddleName = group.MiddleName,
            LastName = group.LastName,
            BirthDate = group.BirthDate,
            Address = group.Address,
            Email = group.Email,
            MobileNumber = group.MobileNumber,
            IsChildOfSoloParent = group.IsChildOfSoloParent,
            IsOnsite = group.IsOnsite,
            IsSoloParent = group.IsSoloParent,
            AcademicProgramChoiceId1 = group.AcademicProgramChoiceId1,
            AcademicProgramChoiceId2 = group.AcademicProgramChoiceId2,
            AcademicProgramChoiceId3 = group.AcademicProgramChoiceId3
        };

        if (!await CreateAsync(admissionApplicant))
        {
            return null;
        }

        List<AdmissionApplicantFamilyDetails> parent = new();
        // Father
        parent.Add(new AdmissionApplicantFamilyDetails { 
            AdmissionApplicantId = admissionApplicant.Id,
            FirstName = group.Father.FirstName,
            LastName = group.Father.LastName,
            Address = group.Father.Address,
            BirthDate = group.Father.BirthDate,
            Occupation = group.Father.Occupation,
            Email = group.Father.Email,
            MonthlyIncome = group.Father.MonthlyIncome,
            Relationship = group.Father.Relationship,
            City = group.Father.City,
            Religion = group.Father.Religion
        });
        // Mother
        parent.Add(new AdmissionApplicantFamilyDetails
        {
            AdmissionApplicantId = admissionApplicant.Id,
            FirstName = group.Mother.FirstName,
            LastName = group.Mother.LastName,
            Address = group.Mother.Address,
            BirthDate = group.Mother.BirthDate,
            Occupation = group.Mother.Occupation,
            Email = group.Mother.Email,
            MonthlyIncome = group.Mother.MonthlyIncome,
            Relationship = group.Mother.Relationship,
            City = group.Mother.City,
            Religion = group.Mother.Religion
        });
        // Sibling
        parent.AddRange(group.Siblings.Select(item => new AdmissionApplicantFamilyDetails {
            AdmissionApplicantId = admissionApplicant.Id,
            FirstName = item.FirstName,
            LastName = item.LastName,
            Address = item.Address,
            BirthDate = item.BirthDate,
            Occupation = null,
            Email = item.Email,
            MonthlyIncome = null,
            Relationship = item.Relationship,
            City = item.City,
            Religion = item.Religion
        }).ToList());

        _dbContext.AdmissionApplicantFamilyDetails.AddRange(parent);
        var createResult = (await _dbContext.SaveChangesAsync()) > 0;

        return (createResult)
            ? admissionApplicant
            : null;
    }
}
