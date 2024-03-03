using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Reviews.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Reviews.Commands.Validators
{
    public class AddReviewValidator : AbstractValidator<AddReviewCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IReviewService _reviewService;
        #endregion

        #region Constructors
        public AddReviewValidator(IStringLocalizer<SharedResources> localizer, IReviewService reviewService)
        {
            _reviewService = reviewService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.TypeAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.TypeEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.TypeAr)
               .MustAsync(async (Key, CancellationToken) => !await _reviewService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.TypeEn)
              .MustAsync(async (Key, CancellationToken) => !await _reviewService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


