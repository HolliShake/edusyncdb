using APPLICATION.Dto.GeneratedSections;
using APPLICATION.Dto.GradeInput;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Service;
public class GradeInputService:GenericService<GradeInput, GetGradeInputDto>, IGradeInputService
{
    public GradeInputService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
