using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ReviewService : IReviewService
    {
        #region Fields
        private readonly IReviewRepository _reviewRepository;
        private readonly ISystemLogService _systemLogService;
        #endregion
        #region Constructors
        public ReviewService(IReviewRepository reviewRepository,
                             ISystemLogService systemLogService)
        {
            _reviewRepository = reviewRepository;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Function
        public async Task<bool> AddReviewAsync(Review review)
        {
            var trans = await _reviewRepository.BeginTransactionAsync();
            try
            {
                await _reviewRepository.AddAsync(review);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = review.Id,
                    TableAr = "نوع مراجعة",
                    TableEn = "Review Type",
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

        public async Task<bool> DeleteReviewAsync(Review review)
        {
            var trans = await _reviewRepository.BeginTransactionAsync();
            try
            {
                await _reviewRepository.DeleteAsync(review);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = review.Id,
                    TableAr = "نوع مراجعة",
                    TableEn = "Review Type",
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

        public IQueryable<Review> GetAll()
        {
            return _reviewRepository.GetTableNoTracking();
        }

        public async Task<Review> GetById(int id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public IQueryable<Review> GetReviewsQuery(string? filter)
        {
            var reviews = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                reviews = reviews.Where(x => x.TypeAr.Contains(filter) ||
                                            x.TypeEn.Contains(filter));
            }
            return reviews.OrderByDescending(x => x.Id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _reviewRepository.GetTableNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsNameArExist(string typeAr)
        {
            return await GetAll().AnyAsync(x => x.TypeAr == typeAr);
        }

        public async Task<bool> IsNameArExistExcludeSelf(string typeAr, int id)
        {
            return await GetAll().AnyAsync(x => x.TypeAr == typeAr && x.Id != id);
        }

        public async Task<bool> IsNameEnExist(string typeEn)
        {
            return await GetAll().AnyAsync(x => x.TypeEn == typeEn);
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string typeEn, int id)
        {
            return await GetAll().AnyAsync(x => x.TypeEn == typeEn && x.Id != id);
        }

        public async Task<bool> UpdateReviewAsync(Review review)
        {
            var trans = await _reviewRepository.BeginTransactionAsync();
            try
            {
                await _reviewRepository.UpdateAsync(review);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = review.Id,
                    TableAr = "نوع مراجعة",
                    TableEn = "Review Type",
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
