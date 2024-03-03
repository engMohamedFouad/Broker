using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Models;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Reviews.Queries.Handlers
{
    public class ReviewQueryHandler : ResponseHandler,
        IRequestHandler<GetReviewPaginationQuery, PaginatedResult<GetReviewPaginationResult>>,
        IRequestHandler<GetReviewByIdQuery, Response<GetReviewByIdResult>>
    {
        #region Fields
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ReviewQueryHandler(IReviewService reviewService,
                                  IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _reviewService=reviewService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetReviewPaginationResult>> Handle(GetReviewPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _reviewService.GetReviewsQuery(request.Search);
            var result = await _mapper.ProjectTo<GetReviewPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetReviewByIdResult>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var concernedParty = await _reviewService.GetById(request.Id);
            if (concernedParty == null) return NotFound<GetReviewByIdResult>();
            var result = _mapper.Map<GetReviewByIdResult>(concernedParty);
            return Success(result);
        }

        #endregion
    }
}
