using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Models;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Handlers
{
    public class ReviewPointsQueryHandler : ResponseHandler,
        IRequestHandler<GetReviewPointsQuery, PaginatedResult<GetReviewPointsResult>>,
        IRequestHandler<GetReviewPointByIdQuery, Response<GetReviewPointByIdResult>>
    {
        #region Fields
        private readonly IReviewPointsService _reviewPointsService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ReviewPointsQueryHandler(IReviewPointsService reviewPointsService,
                                        IStringLocalizer<SharedResources> stringLocalizer,
                                        IMapper mapper) : base(stringLocalizer)
        {
            _reviewPointsService = reviewPointsService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetReviewPointsResult>> Handle(GetReviewPointsQuery request, CancellationToken cancellationToken)
        {
            var reviewPoints = _reviewPointsService.GetReviewPointsQuery(request.Search);
            var result = await _mapper.ProjectTo<GetReviewPointsResult>(reviewPoints).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetReviewPointByIdResult>> Handle(GetReviewPointByIdQuery request, CancellationToken cancellationToken)
        {
            var reviewPoint = await _reviewPointsService.GetReviewPointsById(request.Id);
            if (reviewPoint == null) return NotFound<GetReviewPointByIdResult>();
            var mapper = _mapper.Map<GetReviewPointByIdResult>(reviewPoint);
            var completeDomainForImages = _reviewPointsService.CompleteDomainForImage(mapper.Files);
            mapper.Files = completeDomainForImages;
            return Success(mapper);
        }
        #endregion
    }
}
