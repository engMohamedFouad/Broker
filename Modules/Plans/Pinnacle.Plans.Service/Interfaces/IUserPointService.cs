using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IUserPointService
    {
        public Task<List<UserPoint>> GetUsersByPointId(int pointId);
        public Task<bool> AddUserToPointAsync(UserPoint userPoint);
        public Task<bool> DeleteUserToPointAsync(UserPoint userPoint);
        public Task<UserPoint> GetUserByPointIdAsync(int pointId, int userId);
        public Task<bool> IsExist(int pointId, int userId);
    }
}
