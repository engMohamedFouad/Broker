using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Reviews.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Reviews.Commands.Handlers
{
    public class ReviewCommandHandler : ResponseHandler,
        IRequestHandler<AddReviewCommand, Response<string>>,
        IRequestHandler<UpdateReviewCommand, Response<string>>,
        IRequestHandler<DeleteReviewCommand, Response<string>>
    {
        #region Fields
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ReviewCommandHandler(IReviewService reviewService,
                                    IMapper mapper,
                                    IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _reviewService= reviewService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);
            var result = await _reviewService.AddReviewAsync(review);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewService.GetById(request.Id);
            if (review == null) return NotFound<string>();
            var mapper = _mapper.Map(request, review);
            var result = await _reviewService.UpdateReviewAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewService.GetById(request.Id);
            if (review == null) return NotFound<string>();
            var result = await _reviewService.DeleteReviewAsync(review);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }
        #endregion
    }
}

