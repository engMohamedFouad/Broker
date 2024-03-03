using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.PointComments.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.PointComments.Commands.Handlers
{
    public class PointCommentsCommandHandler : ResponseHandler,
        IRequestHandler<AddPointCommentsCommand, Response<string>>,
        IRequestHandler<UpdatePointCommentsCommand, Response<string>>,
        IRequestHandler<DeletePointCommentsCommand, Response<string>>
    {
        #region Fields
        private readonly IPointsCommentsService _pointsCommentsService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public PointCommentsCommandHandler(IPointsCommentsService pointsCommentsService,
                                           IMapper mapper,
                                           IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _pointsCommentsService = pointsCommentsService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddPointCommentsCommand request, CancellationToken cancellationToken)
        {
            var pointComment = _mapper.Map<PointsComments>(request);
            var result = await _pointsCommentsService.AddPointsCommentsAsync(pointComment);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdatePointCommentsCommand request, CancellationToken cancellationToken)
        {
            var pointComment = await _pointsCommentsService.GetById(request.Id);
            if (pointComment == null) return NotFound<string>();
            var mapper = _mapper.Map(request, pointComment);
            var result = await _pointsCommentsService.UpdatePointsCommentsAsync(mapper);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeletePointCommentsCommand request, CancellationToken cancellationToken)
        {
            var yearlyPlan = await _pointsCommentsService.GetById(request.Id);
            if (yearlyPlan == null) return NotFound<string>();
            var result = await _pointsCommentsService.DeletePointsCommentsAsync(yearlyPlan);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }
        #endregion
    }
}
