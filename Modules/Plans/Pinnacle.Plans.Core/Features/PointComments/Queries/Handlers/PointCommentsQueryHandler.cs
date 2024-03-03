using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Models;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.PointComments.Queries
{
    public class PointCommentsQueryHandler : ResponseHandler,
        IRequestHandler<GetPointsCommentsQuery, Response<List<GetPointsCommentsResult>>>,
        IRequestHandler<GetPointsCommentsByIdQuery, Response<GetPointsCommentsByIdResult>>
    {
        #region Fields
        private readonly IPointsCommentsService _pointsCommentsService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public PointCommentsQueryHandler(IPointsCommentsService pointsCommentsService,
                                         IMapper mapper,
                                         IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _pointsCommentsService = pointsCommentsService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Fumctions
        public async Task<Response<List<GetPointsCommentsResult>>> Handle(GetPointsCommentsQuery request, CancellationToken cancellationToken)
        {
            var query = _pointsCommentsService.GetPointsCommentsQuery(request.PointId);
            var result = _mapper.Map<List<GetPointsCommentsResult>>(query);
            return Success(result);
        }

        public async Task<Response<GetPointsCommentsByIdResult>> Handle(GetPointsCommentsByIdQuery request, CancellationToken cancellationToken)
        {
            var pointComment = await _pointsCommentsService.GetById(request.Id);
            if (pointComment == null) return NotFound<GetPointsCommentsByIdResult>();
            var result = _mapper.Map<GetPointsCommentsByIdResult>(pointComment);
            return Success(result);
        }
        #endregion
    }
}
