using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Handlers
{
    public class ReviewTopicsCommandHandler : ResponseHandler,
        IRequestHandler<AddReviewTopicsCommand, Response<string>>,
        IRequestHandler<UpdateReviewTopicsCommand, Response<string>>,
        IRequestHandler<DeleteReviewTopicsCommand, Response<string>>
    {
        #region Fields
        private readonly IReviewTopicService _reviewTopicService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ReviewTopicsCommandHandler(IReviewTopicService reviewTopicService,
                                          IMapper mapper,
                                          IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _reviewTopicService=reviewTopicService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddReviewTopicsCommand request, CancellationToken cancellationToken)
        {
            var reviewtopic = _mapper.Map<ReviewTopic>(request);
            var result = await _reviewTopicService.AddReviewTopicAsync(reviewtopic);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateReviewTopicsCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewTopicService.GetById(request.Id);
            if (review == null) return NotFound<string>();
            var mapper = _mapper.Map(request, review);
            var result = await _reviewTopicService.UpdateReviewTopicAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteReviewTopicsCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewTopicService.GetById(request.Id);
            if (review == null) return NotFound<string>();
            var result = await _reviewTopicService.DeleteReviewTopicAsync(review);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }
        #endregion
    }
}
