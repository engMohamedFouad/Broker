using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.SystemLogs.Queries.Models;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.SystemLogs.Queries.Handlers
{
    public class SystemLogsQueryHandler : ResponseHandler,
        IRequestHandler<GetSystemLogsQuery, PaginatedResult<GetSystemLogsResult>>
    {
        #region Fields
        private readonly ISystemLogService _systemLogService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public SystemLogsQueryHandler(ISystemLogService systemLogService,
                                      IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetSystemLogsResult>> Handle(GetSystemLogsQuery request, CancellationToken cancellationToken)
        {
            var response = _systemLogService.GetSystemLogs();
            var result = await response.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
        #endregion
    }
}
