using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Validators
{
    public class UpdateReviewPointsValidator : AbstractValidator<UpdateReviewPointsCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IIndicatorService _indicatorService;
        #endregion

        #region Constructors
        public UpdateReviewPointsValidator(IStringLocalizer<SharedResources> localizer,
                                        IIndicatorService indicatorService)
        {
            _indicatorService = indicatorService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.IndicatorId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.IndicatorId)
                .MustAsync(async (Key, CancellationToken) => await _indicatorService.IsExist((int)Key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}