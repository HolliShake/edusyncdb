
using APPLICATION.IService;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service;
public class FileTableService:GenericService<FileTable>, IFileTableService
{
    public FileTableService(AppDbContext context):base(context)
    {
    }
}
