using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.UserPoints.Queries.Models;
using Pinnacle.Plans.Core.Features.UserPoints.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.UserPoints.Queries.Handlers
{
    public class UserPointQueryHandler : ResponseHandler,
        IRequestHandler<GetUsersAssignedByPointIdQuery, Response<List<GetUsersAssignedByPointIdResult>>>
    {
        #region Fields
        private readonly IUserPointService _userPointService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public UserPointQueryHandler(IUserPointService userPointService,
                                  IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userPointService = userPointService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<List<GetUsersAssignedByPointIdResult>>> Handle(GetUsersAssignedByPointIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _userPointService.GetUsersByPointId(request.PointId);
            var result = _mapper.Map<List<GetUsersAssignedByPointIdResult>>(query);
            return Success(result);
        }
        #endregion
    }
}
