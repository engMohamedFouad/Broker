using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.UserPoints.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.UserPoints.Commands.Handlers
{
    public class UserPointCommandHandler : ResponseHandler,
        IRequestHandler<AddUserPointCommand, Response<string>>,
        IRequestHandler<DeleteUserPointCommand, Response<string>>
    {
        #region Fields
        private readonly IUserPointService _userPointService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public UserPointCommandHandler(IUserPointService userPointService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _userPointService = userPointService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserPointCommand request, CancellationToken cancellationToken)
        {
            var userPoint = _mapper.Map<UserPoint>(request);
            var result = await _userPointService.AddUserToPointAsync(userPoint);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(DeleteUserPointCommand request, CancellationToken cancellationToken)
        {
            var userPoint = await _userPointService.GetUserByPointIdAsync(request.PointId, request.UserId);
            if (userPoint == null) return NotFound<string>();
            var result = await _userPointService.DeleteUserToPointAsync(userPoint);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}
