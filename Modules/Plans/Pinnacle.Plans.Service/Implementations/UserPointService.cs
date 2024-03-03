using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Entities.Identity;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class UserPointService : IUserPointService
    {
        #region Fields
        private readonly IUserPointRepository _userPointRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public UserPointService(IUserPointRepository userPointRepository,
                                ISystemLogService systemLogService,
                                UserManager<User> userManager)
        {
            _userPointRepository = userPointRepository;
            _systemLogService = systemLogService;
            _userManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddUserToPointAsync(UserPoint userPoint)
        {
            var trans = await _userPointRepository.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(userPoint.UId.ToString());
                await _userPointRepository.AddAsync(userPoint);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = userPoint.PId,
                    TableAr = $"{userPoint.PId} الي نقطة رقم {user.UserName} مستخدم ",
                    TableEn = $"User {user.UserName} to point number {userPoint.PId}",
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

        public async Task<bool> DeleteUserToPointAsync(UserPoint userPoint)
        {
            var trans = await _userPointRepository.BeginTransactionAsync();
            try
            {
                var user = await _userManager.FindByIdAsync(userPoint.UId.ToString());
                await _userPointRepository.ExecSQLAsync($"delete from UserPoint where PId={userPoint.PId} and UId={userPoint.UId}");

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = userPoint.PId,
                    TableAr = $"{userPoint.PId} الي نقطة رقم {user.UserName} مستخدم ",
                    TableEn = $"User {user.UserName} to point number {userPoint.PId}",
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

        public async Task<UserPoint> GetUserByPointIdAsync(int pointId, int userId)
        {
            return await _userPointRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.PId == pointId && x.UId == userId);
        }

        public async Task<List<UserPoint>> GetUsersByPointId(int pointId)
        {
            return await _userPointRepository.GetTableNoTracking().Include(x => x.UserNavigation).Where(x => x.PId == pointId).ToListAsync();
        }

        public async Task<bool> IsExist(int pointId, int userId)
        {
            return await _userPointRepository.GetTableNoTracking().AnyAsync(x => x.UId == userId && x.PId == pointId);
        }
        #endregion
    }
}
