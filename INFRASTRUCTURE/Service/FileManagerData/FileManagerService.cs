using AutoMapper;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using APPLICATION.Dto.FileManager;
using APPLICATION.IService.FileManagerData;
using DOMAIN.Model;
using INFRASTRUCTURE.Data;

namespace INFRASTRUCTURE.Service.FileManagerData;

public class FileManagerService : GenericService<FileTable, GetFileManagerTableDto>, IFileManagerService
{
    public FileManagerService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<List<GetFileManagerTableDto>> GetFileByScopeAndRefereneId(string scope, string refId)
    {
        return _mapper.Map<List<GetFileManagerTableDto>>(await _dbModel.Where(file => file.ReferenceId == refId).Where(file => file.Scope.Equals(scope)).ToListAsync());
    }

    public async Task<List<GetFileManagerTableDto>> GetFileByScope(string scope)
    {
        return _mapper.Map<List<GetFileManagerTableDto>>(await _dbModel.Where(file => file.Scope.Equals(scope)).ToListAsync());
    }

    public async Task<List<GetFileManagerTableDto>> GetFileByScopeAndReferenceId(string scope, string referenceId)
    {
        return _mapper.Map<List<GetFileManagerTableDto>>(await _dbModel.Where(file => file.Scope.Equals(scope) && file.ReferenceId.Equals(referenceId.ToString())).ToListAsync());
    }

    public async Task<GetFileManagerTableDto?> UploadFile(ConfigurationManager configuration, string scope, string referenceId, IFormFile file)
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
            ReferenceId = referenceId,
            UploadDate = DateTime.Now
        });

        var saved = await Save();

        return saved
            ? _mapper.Map<GetFileManagerTableDto?>(result.Entity)
            : null;
    }

    public async Task<ICollection<GetFileManagerTableDto>?> UploadMultipleFile(ConfigurationManager configuration, string scope, string referenceId, List<IFormFile> files)
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
                    ReferenceId = referenceId
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

    public async Task<GetFileManagerTableDto?> UpdateFile(ConfigurationManager configuration, int id, IFormFile file)
    {
        var oldRecord = await _dbModel.FindAsync(id);

        if (oldRecord == null)
        {
            return null;
        }

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

            var segments = oldRecord.Scope.Split(":");
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

        var oldFile = oldRecord.FileName;

        oldRecord.FileName = fileName;
        oldRecord.FileType = extension;

        var result = await UpdateAsync(oldRecord);

        if ((result != null) && await DeleteFile(configuration, oldRecord.Scope, oldRecord.ReferenceId, oldFile));

        return result;
    }

    public async Task<bool> DeleteFile(ConfigurationManager configuration, string scope, string refId, string fileName)
    {
        var uploadPath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? Path.Combine(configuration["File:LocationWIN32"], configuration["File:DestinationWIN32"])
            : Path.Combine(configuration["File:LocationLINUX"], configuration["File:DestinationLINUX"]);

        var file = _mapper.Map<GetFileManagerTableDto>(await _dbModel
            .Where(ft => ft.ReferenceId == refId)
            .Where(ft => ft.Scope       == scope)
            .Where(ft => ft.FileName    == fileName)
            .FirstOrDefaultAsync());


        if (file == null)
        {
            return false;
        }

        try
        {
            System.IO.File.Delete(Path.Combine(uploadPath, file.ScopePath));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}