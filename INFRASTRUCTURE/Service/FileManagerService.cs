using System.Runtime.InteropServices;
using System.Text;
using APPLICATION.Dto.FileManager;
using APPLICATION.IService;
using AutoMapper;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace INFRASTRUCTURE.Service;

public class FileManagerService : GenericService<FileTable, GetFileManagerTableDto>, IFileManagerService
{
    public FileManagerService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<List<GetFileManagerTableDto>> GetFileByScope(string scope)
    {
        return _mapper.Map<List<GetFileManagerTableDto>>(await _dbModel.Where(file => file.Scope.Equals(scope)).ToListAsync());
    }

    public async Task<List<GetFileManagerTableDto>> GetFileByScopeAndReferenceId(string scope, int referenceId)
    {
        return _mapper.Map<List<GetFileManagerTableDto>>(await _dbModel.Where(file => file.Scope.Equals(scope) && file.ReferenceId.Equals(referenceId.ToString())).ToListAsync());
    }

    public async Task<GetFileManagerTableDto?> UploadFile(ConfigurationManager configuration, string scope, int referenceId, IFormFile file)
    {
        var uploadPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Path.Combine(configuration["File:LocationWIN32"], configuration["File:DestinationWIN32"])
            : Path.Combine(configuration["File:LocationLINUX"], configuration["File:DestinationLINUX"]);

        var reader = new StreamReader(file.OpenReadStream(), Encoding.UTF8);

        var names = file.FileName.Split('.');
        var extension = "." + names[^1];

        string fileName;
        try
        {
            var content = reader.ReadToEnd();

            fileName = Path.GetRandomFileName() + $"-{Guid.NewGuid()}" + extension;
            var targetPath = Path.Combine(uploadPath, "");

            var segments = scope.Split(":");
            foreach (var segment in segments)
            {
                targetPath = Path.Combine(targetPath, segment);

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);

                var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                await file.CopyToAsync(stream);
            }
            else
            {
                // Store
                var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }
        catch (Exception)
        {
            return null;
        }

        var result = await _dbModel.AddAsync(new FileTable
        {
            FileName = fileName,
            FileType = extension,
            Scope = scope,
            ReferenceId = referenceId.ToString(),
            UploadDate = DateTime.Now
        });

        var saved = await Save();

        return saved
            ? _mapper.Map<GetFileManagerTableDto?>(result.Entity)
            : null;
    }

    public async Task<ICollection<GetFileManagerTableDto>?> UploadMultipleFile(ConfigurationManager configuration, string scope, int referenceId, List<IFormFile> files)
    {
        var uploadPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Path.Combine(configuration["File:LocationWIN32"], configuration["File:DestinationWIN32"])
            : Path.Combine(configuration["File:LocationLINUX"], configuration["File:DestinationLINUX"]);

        if (files.Count <= 0)
        {
            return null;
        }

        var items = new List<FileTable>();

        foreach (var file in files)
        {
            var names = file.FileName.Split('.');
            var extension = "." + names[^1];

            string fileName;
            try
            {
                fileName = Path.GetRandomFileName() + $"-{Guid.NewGuid()}" + extension;
                var targetPath = Path.Combine(uploadPath, "");

                var segments = scope.Split(":");
                foreach (var segment in segments)
                {
                    targetPath = Path.Combine(targetPath, segment);

                    if (!Directory.Exists(targetPath))
                    {
                        Directory.CreateDirectory(targetPath);
                    }
                }

                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);

                    var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                    await file.CopyToAsync(stream);
                }
                else
                {
                    // Store
                    var stream = new FileStream(Path.Combine(targetPath, fileName), FileMode.Create);
                    await file.CopyToAsync(stream);
                }

                items.Add(new FileTable
                {
                    FileName = fileName,
                    FileType = extension,
                    Scope = scope,
                    ReferenceId = referenceId.ToString()
                });
            }
            catch (Exception)
            {
                return null;
            }
        }

        await _dbModel.AddRangeAsync(items);

        return (await Save())
            ? _mapper.Map<ICollection<GetFileManagerTableDto>>(items)
            : null;
    }
}