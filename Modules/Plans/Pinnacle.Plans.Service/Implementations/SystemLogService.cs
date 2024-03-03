using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrastructure.Builders.AuthServices.Interfaces;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class SystemLogService : ISystemLogService
    {
        #region Fields
        private readonly ISystemLogRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        #endregion
        #region Constructors
        public SystemLogService(ISystemLogRepository repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }
        #endregion
        #region Handle functions
        public async Task<bool> AddSystemLog(SystemLog log)
        {
            log.UserId = _currentUserService.GetUserId();
            await _repository.AddAsync(log);
            return true;
        }

        public IQueryable<GetSystemLogsResult> GetSystemLogs()
        {
            var repository = _repository.GetTableNoTracking();
            var userName = _currentUserService.GetUserAsync().Result.UserName;
            return repository.OrderByDescending(x => x.Id).Select(x => new GetSystemLogsResult()
            {
                Id = (int)x.ItemId,
                Statement = x.Localize($"{x.TableAr} {x.OperationNavigation.NameAr}ب {userName} قام ", $"{userName} {x.OperationNavigation.NameEn} {x.TableEn}")
            });
        }

        #endregion
    }
}
