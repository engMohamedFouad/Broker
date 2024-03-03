using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IReviewTopicService
    {
        public IQueryable<ReviewTopic> GetAll();
        public IQueryable<ReviewTopic> GetReviewTopicsQuery(string? filter);
        public Task<ReviewTopic> GetById(int id);
        public Task<bool> AddReviewTopicAsync(ReviewTopic reviewTopic);
        public Task<bool> UpdateReviewTopicAsync(ReviewTopic reviewTopic);
        public Task<bool> DeleteReviewTopicAsync(ReviewTopic reviewTopic);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
