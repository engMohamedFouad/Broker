using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Entities.Identity;
using Pinnacle.Data.Enums;
using Pinnacle.Infrastructure.Builders.AuthServices.Interfaces;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ProcedureDetailsService : IProcedureDetailsService
    {
        #region Fields
        private readonly IProcedureDetailsRepository _procedureDetailsRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly IFilesRepository _filesRepository;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IProcedureDetailsFileRepository _procedureDetailsFileRepository;
        private readonly IIndicatorsRepository _indicatorRepository;
        private readonly IIndicatorProcedureRepository _indicatorProcedureRepository;
        #endregion
        #region Constructors
        public ProcedureDetailsService(IProcedureDetailsRepository procedureDetailsRepository,
                                       ISystemLogService systemLogService,
                                       IFilesRepository filesRepository,
                                       UserManager<User> userManager,
                                       ICurrentUserService currentUserService,
                                       IFileService fileService,
                                       IProcedureDetailsFileRepository procedureDetailsFileRepository,
                                       IIndicatorsRepository indicatorRepository,
                                       IIndicatorProcedureRepository indicatorProcedureRepository)
        {
            _procedureDetailsRepository = procedureDetailsRepository;
            _systemLogService = systemLogService;
            _filesRepository = filesRepository;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _fileService = fileService;
            _procedureDetailsFileRepository = procedureDetailsFileRepository;
            _indicatorRepository = indicatorRepository;
            _indicatorProcedureRepository = indicatorProcedureRepository;
        }
        #endregion

        #region Handle Functions
        public async Task<string> AddProcedureDetailsAsync(ProcedureDetails procedureDetail, List<IFormFile> files)
        {
            var trans = await _procedureDetailsRepository.BeginTransactionAsync();
            try
            {
                //Adding procedureDetails
                await _procedureDetailsRepository.AddAsync(procedureDetail);
                //every file can use with many ProcedureDetail and ProcedureDetail can have many files.
                //So there is relation Many to many between them.
                var finialFiles = new List<Files>();
                procedureDetail.UserId = _currentUserService.GetUserId();
                if (files.Count() > 0)
                {
                    var result = await AddFilesToDatabase(files, procedureDetail);
                    if (result.Item2 != "Success") return result.Item2;
                    finialFiles = result.Item1;
                }

                if (finialFiles != null && finialFiles.Count() > 0)
                {
                    //Added Relations between Files and ProcedureDetail
                    await AddedRelationBetweenProcedureDetailsAndFiles(finialFiles, procedureDetail.Id);
                }

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = procedureDetail.Id,
                    TableAr = "اجراء",
                    TableEn = "Procedure",
                });
                await trans.CommitAsync();
                return "Success";

            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> DeleteProcedureDetailsAsync(ProcedureDetails procedureDetail)
        {
            var trans = await _procedureDetailsRepository.BeginTransactionAsync();
            try
            {
                //Delete procedureDetail
                await _procedureDetailsRepository.DeleteAsync(procedureDetail);
                var procedureDetailFiles = procedureDetail.ProcedureDetailFileNavigations;

                if (procedureDetailFiles != null && procedureDetailFiles.Count() > 0)
                {
                    //Delete Relations in table ProcedureDetailsFile
                    var result = await DeleteFilesFromDatabaseAndPhysical(procedureDetailFiles);
                    if (result != "Success")
                    {
                        return result;
                    }
                }

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = procedureDetail.Id,
                    TableAr = "اجراء",
                    TableEn = "Procedure",
                });
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public IQueryable<ProcedureDetails> GetAll()
        {
            return _procedureDetailsRepository.GetTableNoTracking();
        }

        public async Task<ProcedureDetails> GetByIdAsync(int id)
        {
            return await _procedureDetailsRepository.GetTableNoTracking()
                                                    .Include(x => x.ProcedureDetailFileNavigations)
                                                    .ThenInclude(x => x.fileNavigation)
                                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IQueryable<ProcedureDetails>?> GetProcedureDetailsQuery(string search, int planId, int indicatorId)
        {
            //GetIndicator for specific plan
            var indicator = await _indicatorRepository.GetTableNoTracking()
                                                    .Include(x => x.IndicatorProcedureNavigations.Where(x => x.PlanId == planId))
                                                    .FirstOrDefaultAsync(x => x.Id == indicatorId);
            if (indicator != null)
            {
                //Get procedures
                var procedures = indicator.IndicatorProcedureNavigations.ToList();

                var procedureDetails = GetAll().Include(x => x.ProcedureNavigation)
                                               .Include(x => x.ProcedureDetailFileNavigations)
                                               .Include(x => x.UserNavigation)
                                               .Where(x => x.PlanId == planId && (procedures.Select(p => p.ProcedureId).Contains((int)x.ProcedureId)))
                                               .AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    procedureDetails = procedureDetails.Where(x => x.ProcedureNavigation.NameAr.Contains(search) ||
                                                                   x.ProcedureNavigation.NameAr.Contains(search));
                }
                return procedureDetails.OrderByDescending(x => x.Id);
            }
            return null;
        }

        public async Task<string> UpdateProcedureDetailsAsync(ProcedureDetails procedureDetail, List<IFormFile> files)
        {
            var trans = await _procedureDetailsRepository.BeginTransactionAsync();
            try
            {
                procedureDetail.UserId = _currentUserService.GetUserId();
                await _procedureDetailsRepository.UpdateAsync(procedureDetail);
                //If file ==null mean not change in any file, just update details.
                if (files != null)
                {
                    //files Paths from database
                    var procedureDetailFiles = procedureDetail.ProcedureDetailFileNavigations;
                    //remove and added new files
                    if (procedureDetailFiles != null && procedureDetailFiles.Count() > 0)
                    {
                        //Delete Relations in table ProcedureDetailsFile
                        var result = await DeleteFilesFromDatabaseAndPhysical(procedureDetailFiles);
                        if (result != "Success")
                        {
                            return result;
                        }
                    }

                    //Added the New Files after delete all in Database and Physical Files and relations
                    var finialFiles = new List<Files>();
                    procedureDetail.UserId = _currentUserService.GetUserId();
                    if (files.Count() > 0)
                    {
                        var result = await AddFilesToDatabase(files, procedureDetail);
                        if (result.Item2 != "Success") return result.Item2;
                        finialFiles = result.Item1;
                    }

                    if (finialFiles != null && finialFiles.Count() > 0)
                    {
                        //Added Relations between Files and ProcedureDetail
                        await AddedRelationBetweenProcedureDetailsAndFiles(finialFiles, procedureDetail.Id);
                    }
                    //Added logs
                    await _systemLogService.AddSystemLog(new SystemLog()
                    {
                        OperationId = (int)SystemOperationsEnum.Update,
                        ItemId = procedureDetail.Id,
                        TableAr = "اجراء",
                        TableEn = "Procedure",
                    });


                    await trans.CommitAsync();
                    return "Success";
                }
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        private async Task<string> DeleteFilesFromDatabaseAndPhysical(List<ProcedureDetailFile> procedureDetailFiles)
        {
            //Delete Relations in table ProcedureDetailsFile
            await _procedureDetailsFileRepository.DeleteRangeAsync(procedureDetailFiles);

            //Delete Files from table Files in Database
            if (procedureDetailFiles != null && procedureDetailFiles.Count > 0)
            {
                foreach (var file in procedureDetailFiles)
                {
                    //delete all files of indicatorDetails
                    await _procedureDetailsRepository.ExecSQLAsync($"Delete From Files where Id={file.FileId}");
                }
                //Delete the physical files from their folders
                var result = _fileService.DeleteFileLocal(procedureDetailFiles.Select(x => x.fileNavigation.Content).ToList());
                if (result == "Failed")
                {
                    return "FaliedToDeletePhysialFiles";
                }
            }
            return "Success";
        }
        private async Task<(List<Files>?, string)> AddFilesToDatabase(List<IFormFile> files, ProcedureDetails procedureDetail)
        {
            var finialFiles = new List<Files>();
            //Adding files 
            var filesPaths = await _fileService.UploadImage("Files", files);
            //in case failed to upload images
            if (filesPaths.Any(x => x.FileName == "FailedToUploadFiles"))
            {
                return (null, "FailedToUploadFiles");
            }

            foreach (var file in filesPaths)
            {
                finialFiles.Add(new Files { Content = file.Path, YPId = procedureDetail.PlanId, UserId = procedureDetail.UserId, FileName = file.FileName, Id = null });
            }
            try
            {
                await _filesRepository.AddRangeAsync(finialFiles);
                return (finialFiles, "Success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private async Task AddedRelationBetweenProcedureDetailsAndFiles(List<Files> finialFiles, int id)
        {
            var procedureDetailsFiles = new List<ProcedureDetailFile>();
            foreach (var file in finialFiles)
            {
                procedureDetailsFiles.Add(new ProcedureDetailFile { FileId = (int)file.Id, ProcedureDetailId = id });
            }
            await _procedureDetailsFileRepository.AddRangeAsync(procedureDetailsFiles);

        }
        #endregion

    }
}
