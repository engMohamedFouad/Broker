using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Data.Helpers;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class FileService : IFileService
    {
        #region Fileds
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICurrentUrlService _currentUrlService;
        private readonly IFilesRepository _filesRepository;
        private readonly ISystemLogService _systemLogService;

        #endregion
        #region Constructors
        public FileService(IWebHostEnvironment webHostEnvironment,
                           ICurrentUrlService currentUrlService,
                           IFilesRepository filesRepository,
                           ISystemLogService systemLogService)
        {
            _webHostEnvironment = webHostEnvironment;
            _currentUrlService = currentUrlService;
            _filesRepository = filesRepository;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Functions
        public async Task<List<FilesResponse>> UploadImage(string Location, List<IFormFile> files)
        {
            var result = new List<FilesResponse>();
            var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var file in files)
                {
                    var fileName = file.FileName;
                    using (FileStream filestreem = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(filestreem);
                        await filestreem.FlushAsync();
                        result.Add(new FilesResponse() { Path = $"/{Location}/{fileName}", FileName = fileName });
                    }
                }
                return result;
            }
            catch (Exception)
            {
                result.Add(new FilesResponse() { FileName = "FailedToUploadFiles", Path = "" });
                return result;
            }
        }

        public string DeleteFileLocal(List<string> filesUrl)
        {
            try
            {
                foreach (var file in filesUrl)
                {
                    // var path = _webHostEnvironment.WebRootPath + file;
                    var directoryPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot" + file);
                    if (!File.Exists(directoryPath)) return "NotFound";
                    File.Delete(directoryPath);
                }
                return "Sucess";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public IQueryable<Files> GetAllFiles(string filter, int yPId)
        {
            var files = _filesRepository.GetTableNoTracking().Where(x => x.YPId == yPId);
            if (filter != null)
            {
                files = files.Where(x => x.Serial.Contains(filter) || x.Content.Contains(filter));
            }
            return files.OrderBy(x => x.Id);
        }

        public async Task<string> AddFileAsync(Files file, IFormFile actualFile)
        {
            var trans = await _filesRepository.BeginTransactionAsync();
            try
            {
                var additionFileResult = await addSingleFile(actualFile);
                //first we try To add in database if Oky then add file to folder if not return in all thing
                if (additionFileResult == "FailedToUploadFiles")
                {
                    return "FailedToUploadFiles";
                }
                file.Content = additionFileResult;

                await _filesRepository.AddAsync(file);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = file.Id,
                    TableAr = "ملف",
                    TableEn = "File",
                });

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return "failed";
            }
        }

        public async Task<string> UpdateFileAsync(Files file, IFormFile actualFile)
        {
            var trans = await _filesRepository.BeginTransactionAsync();
            try
            {
                if (actualFile == null)
                {
                    await _filesRepository.UpdateAsync(file);
                    return "Success";
                }
                //if there is actual file to change then delete the past and add again
                //Delete the physical files from their folders
                var ListOfFilesName = new List<string>() { file.FileName };
                var result = DeleteFileLocal(ListOfFilesName);
                if (result == "Failed")
                {
                    return "FaliedToDeletePhysialFiles";
                }
                //This for There are many Transactions so we don't call add
                var additionFileResult = await addSingleFile(actualFile);
                //first we try To add in database if Oky then add file to folder if not return in all thing
                if (additionFileResult == "FailedToUploadFiles")
                {
                    return "FailedToUploadFiles";
                }
                file.Content = additionFileResult;

                await _filesRepository.UpdateAsync(file);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = file.Id,
                    TableAr = "ملف",
                    TableEn = "File",
                });

                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "failed";
            }
        }

        public async Task<string> DeleteFileAsync(Files file)
        {
            var trans = await _filesRepository.BeginTransactionAsync();
            try
            {
                //delete all files of indicatorDetails
                await _filesRepository.ExecSQLAsync($"Delete From Files where Id={file.Id}");

                //Delete the physical files from their folders
                var ListOfFilesName = new List<string>() { file.FileName };
                var result = DeleteFileLocal(ListOfFilesName);
                if (result == "Failed")
                {
                    return "FaliedToDeletePhysialFiles";
                }
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = file.Id,
                    TableAr = "ملف",
                    TableEn = "File",
                });
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "failed";
            }

        }


        private async Task<string> addSingleFile(IFormFile file)
        {
            var path = _webHostEnvironment.WebRootPath + "/Files/";
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = file.FileName;
                using (FileStream filestreem = File.Create(path + fileName))
                {
                    await file.CopyToAsync(filestreem);
                    await filestreem.FlushAsync();
                    return $"/Files/{fileName}";
                }
            }
            catch (Exception)
            {
                return "FailedToUploadFiles";
            }
        }

        public async Task<Files> GetById(int id)
        {
            return await _filesRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
