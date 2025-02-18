using APPLICATION.Dto.FileTable;
using APPLICATION.IService.FileManagerData;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.FileManagerData;

public class FileTableService:GenericService<FileTable, GetFileTableDto>, IFileTableService
{
    public FileTableService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
