using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.AuthenticationAndAuthorization.Service.Abstracts;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.UserPoints.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.UserPoints.Commands.Validators
{
    public class DeleteUserPointValidator : AbstractValidator<DeleteUserPointCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IReviewPointsService _reviewPointsService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IUserPointService _userPointService;
        #endregion

        #region Constructors
        public DeleteUserPointValidator(IStringLocalizer<SharedResources> localizer,
                                     IReviewPointsService reviewPointsService,
                                     IApplicationUserService applicationUserService,
                                     IUserPointService userPointService)
        {
            _reviewPointsService = reviewPointsService;
            _applicationUserService = applicationUserService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _userPointService = userPointService;
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.PointId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.UserId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.PointId)
                .MustAsync(async (Key, CancellationToken) => await _reviewPointsService.IsExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.UserId)
                .MustAsync(async (Key, CancellationToken) => await _applicationUserService.IsUserExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.PointId)
               .MustAsync(async (model, Key, CancellationToken) => await _userPointService.IsExist(Key, model.UserId))
               .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

        }
        #endregion
    }
}
