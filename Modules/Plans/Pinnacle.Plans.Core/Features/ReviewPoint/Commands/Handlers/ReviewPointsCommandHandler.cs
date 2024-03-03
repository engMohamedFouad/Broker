using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Handlers
{
    public class ReviewPointsCommandHandler : ResponseHandler,
        IRequestHandler<AddReviewPointsCommand, Response<string>>,
        IRequestHandler<UpdateReviewPointsCommand, Response<string>>,
        IRequestHandler<DeleteReviewPointsCommand, Response<string>>
    {
        #region Fields
        private readonly IReviewPointsService _reviewPointsService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ReviewPointsCommandHandler(IReviewPointsService reviewPointsService,
                                        IStringLocalizer<SharedResources> stringLocalizer,
                                        IMapper mapper) : base(stringLocalizer)
        {
            _reviewPointsService = reviewPointsService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddReviewPointsCommand request, CancellationToken cancellationToken)
        {
            var mapper = _mapper.Map<ReviewPoints>(request);
            var result = await _reviewPointsService.AddReviewPointsAsync(mapper, request.Files, request.AssignedUsers);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateReviewPointsCommand request, CancellationToken cancellationToken)
        {
            var reviewPoint = await _reviewPointsService.GetReviewPointsById(request.Id);
            if (reviewPoint == null) return NotFound<string>();
            var mapper = _mapper.Map<ReviewPoints>(request);
            var result = await _reviewPointsService.UpdateReviewPointsAsync(mapper, request.Files, request.AssignedUsers);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(DeleteReviewPointsCommand request, CancellationToken cancellationToken)
        {
            var reviewPoint = await _reviewPointsService.GetReviewPointsById(request.Id);
            if (reviewPoint == null) return NotFound<string>();
            var result = await _reviewPointsService.DeleteReviewPointsAsync(reviewPoint);
            switch (result)
            {
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }
        #endregion
    }
}