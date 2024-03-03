using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IPointsCommentsService
    {
        public IQueryable<PointsComments> GetAll();
        public IQueryable<PointsComments> GetPointsCommentsQuery(int PointId);
        public Task<PointsComments> GetById(int id);
        public Task<bool> AddPointsCommentsAsync(PointsComments pointsComment);
        public Task<bool> UpdatePointsCommentsAsync(PointsComments pointsComment);
        public Task<bool> DeletePointsCommentsAsync(PointsComments pointsComment);
    }
}
