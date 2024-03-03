using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Validators
{
    public class AddReviewTopicsValidator : AbstractValidator<AddReviewTopicsCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IReviewTopicService _reviewTopicService;
        #endregion

        #region Constructors
        public AddReviewTopicsValidator(IStringLocalizer<SharedResources> localizer, IReviewTopicService reviewTopicService)
        {
            _reviewTopicService = reviewTopicService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.DescriptionAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.DescriptionEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.DescriptionAr)
              .MustAsync(async (Key, CancellationToken) => !await _reviewTopicService.IsNameArExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DescriptionEn)
              .MustAsync(async (Key, CancellationToken) => !await _reviewTopicService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


