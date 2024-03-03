using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface ISystemLogService
    {
        public Task<bool> AddSystemLog(SystemLog log);
        public IQueryable<GetSystemLogsResult> GetSystemLogs();
    }
}
