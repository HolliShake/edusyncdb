using APPLICATION.Dto.FileManager;
using APPLICATION.IService;
using APPLICATION.Dto.FileTable;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class FileTableService:GenericService<FileTable, GetFileTableDto>, IFileTableService
{
    public FileTableService(AppDbContext context, IMapper mapper):base(context, mapper)
    {
    }
}
