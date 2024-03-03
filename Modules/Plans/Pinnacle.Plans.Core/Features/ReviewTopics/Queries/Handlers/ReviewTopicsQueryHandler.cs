using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Models;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Handlers
{
    public class ReviewTopicsQueryHandler : ResponseHandler,
        IRequestHandler<GetReviewTopicsQuery, PaginatedResult<GetReviewTopicsResult>>,
        IRequestHandler<GetReviewTopicsByIdQuery, Response<GetReviewTopicsByIdResult>>
    {
        #region Fields
        private readonly IReviewTopicService _reviewTopicService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ReviewTopicsQueryHandler(IReviewTopicService reviewTopicService,
                                  IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _reviewTopicService=reviewTopicService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetReviewTopicsResult>> Handle(GetReviewTopicsQuery request, CancellationToken cancellationToken)
        {
            var query = _reviewTopicService.GetReviewTopicsQuery(request.Search);
            var result = await _mapper.ProjectTo<GetReviewTopicsResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetReviewTopicsByIdResult>> Handle(GetReviewTopicsByIdQuery request, CancellationToken cancellationToken)
        {
            var reviewTopics = await _reviewTopicService.GetById(request.Id);
            if (reviewTopics == null) return NotFound<GetReviewTopicsByIdResult>();
            var result = _mapper.Map<GetReviewTopicsByIdResult>(reviewTopics);
            return Success(result);
        }
        #endregion
    }
}