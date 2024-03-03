using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ReviewTopicService : IReviewTopicService
    {
        #region Fields
        private readonly IReviewTopicRepository _reviewTopicRepository;
        private readonly ISystemLogService _systemLogService;
        #endregion
        #region Constructors
        public ReviewTopicService(IReviewTopicRepository reviewTopicRepository,
                                  ISystemLogService systemLogService)
        {
            _reviewTopicRepository = reviewTopicRepository;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddReviewTopicAsync(ReviewTopic reviewTopic)
        {
            var trans = await _reviewTopicRepository.BeginTransactionAsync();
            try
            {
                await _reviewTopicRepository.AddAsync(reviewTopic);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = reviewTopic.Id,
                    TableAr = "بند مراجعة",
                    TableEn = "review Topic",
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

        public async Task<bool> DeleteReviewTopicAsync(ReviewTopic reviewTopic)
        {
            var trans = await _reviewTopicRepository.BeginTransactionAsync();
            try
            {
                await _reviewTopicRepository.DeleteAsync(reviewTopic);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = reviewTopic.Id,
                    TableAr = "بند مراجعة",
                    TableEn = "review Topic",
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

        public IQueryable<ReviewTopic> GetAll()
        {
            return _reviewTopicRepository.GetTableNoTracking();
        }

        public async Task<ReviewTopic> GetById(int id)
        {
            return await _reviewTopicRepository.GetByIdAsync(id);
        }

        public IQueryable<ReviewTopic> GetReviewTopicsQuery(string? filter)
        {
            var reviews = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                reviews = reviews.Where(x => x.DescriptionAr.Contains(filter) ||
                                            x.DescriptionEn.Contains(filter));
            }
            return reviews.OrderByDescending(x => x.Id);
        }

        public async Task<bool> IsNameArExist(string descriptionAr)
        {
            return await GetAll().AnyAsync(x => x.DescriptionAr == descriptionAr);
        }

        public async Task<bool> IsNameArExistExcludeSelf(string descriptionAr, int id)
        {
            return await GetAll().AnyAsync(x => x.DescriptionAr == descriptionAr && x.Id != id);
        }

        public async Task<bool> IsNameEnExist(string descriptionEn)
        {
            return await GetAll().AnyAsync(x => x.DescriptionEn == descriptionEn);
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string descriptionEn, int id)
        {
            return await GetAll().AnyAsync(x => x.DescriptionEn == descriptionEn && x.Id != id);
        }

        public async Task<bool> UpdateReviewTopicAsync(ReviewTopic reviewTopic)
        {
            var trans = await _reviewTopicRepository.BeginTransactionAsync();
            try
            {
                await _reviewTopicRepository.UpdateAsync(reviewTopic);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = reviewTopic.Id,
                    TableAr = "بند مراجعة",
                    TableEn = "review Topic",
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
