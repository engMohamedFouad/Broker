using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IReviewService
    {
        public IQueryable<Review> GetAll();
        public IQueryable<Review> GetReviewsQuery(string? filter);
        public Task<Review> GetById(int id);
        public Task<bool> AddReviewAsync(Review review);
        public Task<bool> UpdateReviewAsync(Review review);
        public Task<bool> DeleteReviewAsync(Review review);
        public Task<bool> IsNameArExist(string typeAr);
        public Task<bool> IsNameArExistExcludeSelf(string typeAr, int id);
        public Task<bool> IsNameEnExist(string typeEn);
        public Task<bool> IsNameEnExistExcludeSelf(string typeEn, int id);
        public Task<bool> IsExist(int id);
    }
}
