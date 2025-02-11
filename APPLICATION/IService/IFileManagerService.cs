using APPLICATION.Dto.FileManager;
using DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace APPLICATION.IService;

public interface IFileManagerService : IGenericService<FileTable, GetFileManagerTableDto>
{
    public Task<List<GetFileManagerTableDto>> GetFileByScopeAndRefereneId(string scope, string refId);
    public Task<List<GetFileManagerTableDto>> GetFileByScope(string scope);
    public Task<List<GetFileManagerTableDto>> GetFileByScopeAndReferenceId(string scope, string referenceId);
    public Task<GetFileManagerTableDto?> UploadFile(ConfigurationManager configuration, string scope, string referenceId, IFormFile file);
    public Task<ICollection<GetFileManagerTableDto>?> UploadMultipleFile(ConfigurationManager configuration, string scope, string referenceId, List<IFormFile> files);
    public Task<GetFileManagerTableDto?> UpdateFile(ConfigurationManager configuration, int id, IFormFile file);
    public Task<bool> DeleteFile(ConfigurationManager configuration, string scope, string refId, string fileName);
}