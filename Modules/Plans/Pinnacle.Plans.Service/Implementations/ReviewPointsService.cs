using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Infrastructure.Builders.AuthServices.Interfaces;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ReviewPointsService : IReviewPointsService
    {
        #region Fields
        private readonly ISystemLogService _logService;
        private readonly IReviewPointsRepository _reviewPointsRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPointCommentsRepository _pointCommentsRepository;
        private int userId;
        private readonly IFileService _fileService;
        private readonly IPointsFilesRepository _pointsFilesRepository;
        private readonly IUserPointRepository _userPointRepository;
        private readonly ICurrentUrlService _currentUrlService;

        #endregion
        #region Constructors
        public ReviewPointsService(ISystemLogService logService,
                                   IReviewPointsRepository reviewPointsRepository,
                                   ICurrentUserService currentUserService,
                                   IPointCommentsRepository pointCommentsRepository,
                                   IFileService fileService,
                                   IPointsFilesRepository pointsFilesRepository,
                                   IUserPointRepository userPointRepository,
                                   ICurrentUrlService currentUrlService)
        {
            _logService = logService;
            _reviewPointsRepository = reviewPointsRepository;
            _currentUserService = currentUserService;
            _pointCommentsRepository = pointCommentsRepository;
            userId = _currentUserService.GetUserId();
            _fileService = fileService;
            _pointsFilesRepository = pointsFilesRepository;
            _userPointRepository = userPointRepository;
            _currentUrlService = currentUrlService;
        }

        #endregion
        #region Handle Functions
        public async Task<string> AddReviewPointsAsync(ReviewPoints reviewPoints, List<IFormFile>? reviewPointsFiles, List<int> assignedUsers)
        {
            var trans = await _reviewPointsRepository.BeginTransactionAsync();
            try
            {
                var currentUser = await _currentUserService.GetUserAsync();
                reviewPoints.UserId = userId;
                await _reviewPointsRepository.AddAsync(reviewPoints);


                //Added userPoint
                var listOfUsers = new List<UserPoint>();
                //Added AssignedUser
                foreach (var user in assignedUsers)
                {
                    var userPoint = new UserPoint()
                    {
                        PId = reviewPoints.Id,
                        UId = user
                    };
                    listOfUsers.Add(userPoint);
                }
                await _userPointRepository.AddRangeAsync(listOfUsers);



                //Added Files When there is files
                if (reviewPointsFiles.Count() > 0)
                {
                    //Adding file
                    var filePaths = await _fileService.UploadImage("ReviewPointsFiles", reviewPointsFiles);
                    //in case failed to upload images
                    if (filePaths.Any(x => x.FileName == "FailedToUploadFiles"))
                    {
                        return "FailedToUploadFiles";
                    }
                    var files = new List<PointsFiles>();
                    foreach (var file in filePaths)
                    {
                        //this for the level of review point so it not have id of any comment
                        files.Add(new PointsFiles { Content = file.Path, PointId = reviewPoints.Id });
                    }
                    await _pointsFilesRepository.AddRangeAsync(files);

                }

                //Added logs
                await _logService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = reviewPoints.Id,
                    TableAr = "نقطة مراجعة",
                    TableEn = "review Point",
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
        public async Task<string> DeleteReviewPointsAsync(ReviewPoints reviewPoints)
        {
            var trans = await _reviewPointsRepository.BeginTransactionAsync();
            try
            {
                await _reviewPointsRepository.DeleteAsync(reviewPoints);
                //Added logs
                await _logService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = reviewPoints.Id,
                    TableAr = "نقطة مراجعة",
                    TableEn = "review Point",
                });


                //remove Points Files
                await _pointsFilesRepository.ExecSQLAsync($"Delete From PointsFiles where PointId={reviewPoints.Id}");

                //files Paths from database
                var filesPathsInDatabase = reviewPoints.FilesNavigations;
                //Delete the physical files from their folders
                var result = _fileService.DeleteFileLocal(filesPathsInDatabase.Select(x => x.Content).ToList());
                if (result == "Failed")
                {
                    return "FaliedToDeletePhysialFiles";
                }

                //remove Old And Added New
                await _userPointRepository.ExecSQLAsync($"Delete From UserPoint where PId={reviewPoints.Id}");

                //remove From PointsComments
                await _pointCommentsRepository.ExecSQLAsync($"Delete From PointsComments where PointId={reviewPoints.Id}");


                await trans.CommitAsync();

                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<ReviewPoints> GetReviewPointsById(int id)
        {
            return await _reviewPointsRepository.GetTableNoTracking()
                                                .Include(x => x.FilesNavigations)
                                                .Include(x => x.IndicatorNavigation)
                                                .Include(x => x.PointsCommentsNavigations)
                                                .Include(x => x.UserNavigation)
                                                .Include(x => x.AssignedUserPointNavigation).ThenInclude(x => x.UserNavigation)
                                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<ReviewPoints> GetReviewPointsQuery(string search)
        {
            var reviewPoints = _reviewPointsRepository.GetTableNoTracking().Include(x => x.IndicatorNavigation).AsQueryable();
            if (search != null)
            {
                reviewPoints = reviewPoints.Where(x => x.IndicatorNavigation.Code.ToString().Contains(search));
            }
            return reviewPoints;
        }

        public async Task<string> UpdateReviewPointsAsync(ReviewPoints reviewPoints, List<IFormFile>? reviewPointsFiles, List<int> assignedUsers)
        {
            var trans = await _reviewPointsRepository.BeginTransactionAsync();
            try
            {
                reviewPoints.UserId = userId;
                await _reviewPointsRepository.UpdateAsync(reviewPoints);
                //Added logs
                await _logService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = reviewPoints.Id,
                    TableAr = "نقطة مراجعة",
                    TableEn = "review Point",
                });

                if (reviewPointsFiles != null)
                {
                    //remove Old and Added New
                    //files Paths from database
                    var filesPathsInDatabase = reviewPoints.FilesNavigations;
                    //remove and added new files
                    await _pointsFilesRepository.ExecSQLAsync($"Delete From PointsFiles where PointId={reviewPoints.Id}");

                    //Delete the physical files from their folders
                    var result = _fileService.DeleteFileLocal(filesPathsInDatabase.Select(x => x.Content).ToList());
                    if (result == "Failed")
                    {
                        return "FaliedToDeletePhysialFiles";
                    }
                    //Adding file
                    var filesPaths = await _fileService.UploadImage("Files", reviewPointsFiles);
                    //in case failed to upload images
                    if (filesPaths.Any(x => x.FileName == "FailedToUploadFiles"))
                    {
                        return "FailedToUploadFiles";
                    }
                    var files = new List<PointsFiles>();
                    foreach (var file in filesPaths)
                    {
                        //this for the level of review point so it not have id of any comment
                        files.Add(new PointsFiles { Content = file.Path, PointId = reviewPoints.Id });
                    }
                    await _pointsFilesRepository.AddRangeAsync(files);
                }


                //In case is not null then it mean there is a change happen.
                if (assignedUsers != null)
                {
                    //remove Old And Added New
                    await _userPointRepository.ExecSQLAsync($"Delete From UserPoint where PId={reviewPoints.Id}");
                    //Added userPoint
                    var listOfUsers = new List<UserPoint>();
                    //Added AssignedUser
                    foreach (var user in assignedUsers)
                    {
                        var userPoint = new UserPoint()
                        {
                            PId = reviewPoints.Id,
                            UId = user
                        };
                        listOfUsers.Add(userPoint);
                    }
                    await _userPointRepository.AddRangeAsync(listOfUsers);
                }

                await trans.CommitAsync();

                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public List<PointFilesDTO> CompleteDomainForImage(List<PointFilesDTO>? pointFilesDTOs)
        {
            var domain = _currentUrlService.GetCurrentDomain();
            Parallel.ForEach(pointFilesDTOs, file =>
            {
                file.Content = domain + file.Content;
            });
            return pointFilesDTOs;
        }

        public async Task<bool> IsExist(int id)
        {
            return await _reviewPointsRepository.GetTableNoTracking().AnyAsync(x => x.Id == id);
        }

        #endregion
    }
}
