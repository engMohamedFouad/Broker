using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Infrastructure.Builders.AuthServices.Interfaces;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class PointsCommentsService : IPointsCommentsService
    {
        #region Fields
        private readonly IPointCommentsRepository _pointsCommentsRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly ICurrentUserService _currentUserService;
        private readonly int userId;
        #endregion
        #region Constructors
        public PointsCommentsService(IPointCommentsRepository pointsCommentsRepository,
                                     ISystemLogService systemLogService,
                                     ICurrentUserService currentUserService)
        {
            _pointsCommentsRepository = pointsCommentsRepository;
            _systemLogService = systemLogService;
            _currentUserService = currentUserService;
            userId = _currentUserService.GetUserId();
        }
        #endregion
        #region Handle functions
        public async Task<bool> AddPointsCommentsAsync(PointsComments pointsComment)
        {
            var trans = await _pointsCommentsRepository.BeginTransactionAsync();
            try
            {
                pointsComment.UserId = userId;
                await _pointsCommentsRepository.AddAsync(pointsComment);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    UserId = userId,
                    ItemId = pointsComment.Id,
                    TableAr = "تعليق نقطة",
                    TableEn = "Point Comment",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeletePointsCommentsAsync(PointsComments pointsComment)
        {
            var trans = await _pointsCommentsRepository.BeginTransactionAsync();
            try
            {
                await _pointsCommentsRepository.DeleteAsync(pointsComment);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    UserId = userId,
                    ItemId = pointsComment.Id,
                    TableAr = "تعليق نقطة",
                    TableEn = "Point Comment",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public IQueryable<PointsComments> GetAll()
        {
            return _pointsCommentsRepository.GetTableNoTracking();
        }

        public async Task<PointsComments> GetById(int id)
        {
            return await _pointsCommentsRepository.GetTableNoTracking().Include(x => x.UserNavigation).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<PointsComments> GetPointsCommentsQuery(int PointId)
        {
            return GetAll().Where(x => x.PointId == PointId);
        }

        public async Task<bool> UpdatePointsCommentsAsync(PointsComments pointsComment)
        {
            var trans = await _pointsCommentsRepository.BeginTransactionAsync();
            try
            {
                pointsComment.UserId = userId;
                await _pointsCommentsRepository.UpdateAsync(pointsComment);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    UserId = userId,
                    ItemId = pointsComment.Id,
                    TableAr = "تعليق نقطة",
                    TableEn = "Point Comment",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }
        #endregion
    }
}
