//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Pinnacle.Data.Entities.BasicData;
//using Pinnacle.Data.Entities.Identity;
//using Pinnacle.Data.Enums;
//using Pinnacle.Plans.Data.DTOs.IndicatorsDetails;
//using Pinnacle.Plans.Infrastructure.Abstracts;
//using Pinnacle.Plans.Service.Interfaces;

//namespace Pinnacle.Plans.Service.Implementations
//{
//    public class IndicatorDetailsService : IIndicatorDetailsService
//    {
//        #region Fields
//        private readonly IIndicatorDetailsRepository _indicatorDetailsRepository;
//        private readonly UserManager<User> _userManager;
//        private readonly IFileService _fileService;
//        private readonly IFilesRepository _filesRepository;
//        private readonly ICurrentUrlService _currentUrlService;
//        private readonly ISystemLogService _systemLogService;
//        #endregion
//        #region Constructors
//        public IndicatorDetailsService(IIndicatorDetailsRepository indicatorDetailsRepository,
//                                       UserManager<User> userManager,
//                                       IFileService fileService,
//                                       IFilesRepository filesRepository,
//                                       ICurrentUrlService currentUrlService,
//                                       ISystemLogService systemLogService)
//        {
//            _indicatorDetailsRepository = indicatorDetailsRepository;
//            _userManager = userManager;
//            _fileService = fileService;
//            _filesRepository = filesRepository;
//            _currentUrlService = currentUrlService;
//            _systemLogService = systemLogService;
//        }
//        #endregion
//        #region Handle Functions
//        public async Task<string> AddIndicatorDetailsAsync(IndicatorDetails indicatorDetails, List<IFormFile> files)
//        {
//            var trans = await _indicatorDetailsRepository.BeginTransactionAsync();
//            try
//            {
//                //Adding file
//                await _indicatorDetailsRepository.AddAsync(indicatorDetails);
//                //complete without adding files
//                if (files == null || files.Count() <= 0)
//                {
//                    return "Success";
//                }
//                //Adding file
//                var filesPaths = await _fileService.UploadImage("Files", files);
//                //in case failed to upload images
//                if (filesPaths.Any(x => x == "FailedToUploadFiles"))
//                {
//                    return "FailedToUploadFiles";
//                }
//                var finialFiles = new List<Files>();
//                foreach (var file in filesPaths)
//                {
//                    finialFiles.Add(new Files { Content = file, IndDetailsId = indicatorDetails.Id });
//                }
//                await _filesRepository.AddRangeAsync(finialFiles);


//                //Added logs
//                await _systemLogService.AddSystemLog(new SystemLog()
//                {
//                    OperationId = (int)SystemOperationsEnum.Add,
//                    ItemId = indicatorDetails.Id,
//                    TableAr = "اجراء",
//                    TableEn = "Procedure",
//                });


//                await trans.CommitAsync();
//                return "Success";

//            }
//            catch
//            {
//                await trans.RollbackAsync();
//                return "Failed";
//            }
//        }

//        public async Task<string> DeleteIndicatorDetailsAsync(IndicatorDetails indicatorDetail)
//        {
//            var trans = await _indicatorDetailsRepository.BeginTransactionAsync();
//            try

//            {
//                var filesPathsInDatabase = indicatorDetail.FilesNavigation;
//                await _indicatorDetailsRepository.DeleteAsync(indicatorDetail);

//                //files Paths from database
//                // var filesPathsInDatabase = await _filesRepository.GetTableNoTracking().Where(x => x.IndDetailsId==indicatorDetail.Id).ToListAsync();
//                //delete all files of indicatorDetails
//                await _indicatorDetailsRepository.ExecSQLAsync($"Delete From Files where IndDetailsId={indicatorDetail.Id}");

//                //Delete the physical files from their folders
//                var result = _fileService.DeleteFileLocal(filesPathsInDatabase.Select(x => x.Content).ToList());
//                if (result == "Failed")
//                {
//                    return "FaliedToDeletePhysialFiles";
//                }

//                //Added logs
//                await _systemLogService.AddSystemLog(new SystemLog()
//                {
//                    OperationId = (int)SystemOperationsEnum.Delete,
//                    ItemId = indicatorDetail.Id,
//                    TableAr = "اجراء",
//                    TableEn = "Procedure",
//                });


//                await trans.CommitAsync();
//                return "Success";
//            }
//            catch
//            {
//                await trans.RollbackAsync();
//                return "Failed";
//            }
//        }

//        public IQueryable<IndicatorDetails> GetAll()
//        {
//            return _indicatorDetailsRepository.GetTableNoTracking();
//        }

//        public async Task<IndicatorDetails> GetById(int id)
//        {
//            return await _indicatorDetailsRepository.GetTableNoTracking().Include(x => x.FilesNavigation).FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public Task<List<IndicatorDetails>> GetIndicatorDetailssQuery(int? indicatorId)
//        {
//            return GetAll().Where(x => x.IndicatorId == indicatorId).Include(x => x.FilesNavigation).OrderBy(x => x.Id).ToListAsync();
//        }

//        public async Task<List<GetIndicatorDetailsByIndicatorIdResult>> GetUserNameAndAddDomainToFileForResults(List<GetIndicatorDetailsByIndicatorIdResult> results)
//        {
//            foreach (var item in results)
//            {
//                var user = await _userManager.FindByIdAsync(item.UserId.ToString());
//                if (user != null)
//                {
//                    item.UserName = user.UserName;
//                }
//                var domain = _currentUrlService.GetCurrentDomain();
//                var newPaths = new List<string>();
//                Parallel.ForEach(item.Files, file =>
//                {
//                    var path = domain + file;
//                    newPaths.Add(path);

//                });
//                item.Files = newPaths;
//            }
//            return results;
//        }

//        public async Task<GetIndicatorDetailsByIdResult> GetUserNameAndAddDomainToFileOfUser(GetIndicatorDetailsByIdResult result)
//        {
//            var user = await _userManager.FindByIdAsync(result.UserId.ToString());
//            if (user != null)
//            {
//                result.UserName = user.UserName;
//            }
//            if (result != null && result.Files.Count() >= 0)
//            {
//                var domain = _currentUrlService.GetCurrentDomain();
//                var newPaths = new List<string>();
//                Parallel.ForEach(result.Files, file =>
//                {
//                    var path = domain + file;
//                    newPaths.Add(path);
//                });
//                result.Files = newPaths;
//            }
//            return result;
//        }

//        public async Task<bool> IsNameArExist(string nameAr)
//        {
//            return await GetAll().AnyAsync(x => x.NameAr == nameAr);
//        }

//        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
//        {
//            return await GetAll().AnyAsync(x => x.NameAr == nameAr && x.Id != id);
//        }

//        public async Task<bool> IsNameEnExist(string nameEn)
//        {
//            return await GetAll().AnyAsync(x => x.NameEn == nameEn);
//        }

//        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
//        {
//            return await GetAll().AnyAsync(x => x.NameEn == nameEn && x.Id != id);
//        }

//        public async Task<string> UpdateIndicatorDetailsAsync(IndicatorDetails indicatorDetail, List<IFormFile> files)
//        {
//            var trans = await _indicatorDetailsRepository.BeginTransactionAsync();
//            try
//            {
//                await _indicatorDetailsRepository.UpdateAsync(indicatorDetail);
//                //If file ==null mean not change in any file, just update details.
//                if (files != null)
//                {
//                    //files Paths from database
//                    var filesPathsInDatabase = indicatorDetail.FilesNavigation;
//                    //remove and added new files
//                    await _indicatorDetailsRepository.ExecSQLAsync($"Delete From Files where IndDetailsId={indicatorDetail.Id}");

//                    //Delete the physical files from their folders
//                    var result = _fileService.DeleteFileLocal(filesPathsInDatabase.Select(x => x.Content).ToList());
//                    if (result == "Failed")
//                    {
//                        return "FaliedToDeletePhysialFiles";
//                    }
//                    //Adding file
//                    var filesPaths = await _fileService.UploadImage("Files", files);
//                    //in case failed to upload images
//                    if (filesPaths.Any(x => x == "FailedToUploadFiles"))
//                    {
//                        return "FailedToUploadFiles";
//                    }
//                    var finialFiles = new List<Files>();
//                    foreach (var file in filesPaths)
//                    {
//                        finialFiles.Add(new Files { Content = file, IndDetailsId = indicatorDetail.Id });
//                    }
//                    await _filesRepository.AddRangeAsync(finialFiles);



//                    //Added logs
//                    await _systemLogService.AddSystemLog(new SystemLog()
//                    {
//                        OperationId = (int)SystemOperationsEnum.Update,
//                        ItemId = indicatorDetail.Id,
//                        TableAr = "اجراء",
//                        TableEn = "Procedure",
//                    });


//                    await trans.CommitAsync();
//                    return "Success";
//                }
//                return "Success";
//            }
//            catch
//            {
//                await trans.RollbackAsync();
//                return "Failed";
//            }
//        }
//        #endregion
//    }
//}
