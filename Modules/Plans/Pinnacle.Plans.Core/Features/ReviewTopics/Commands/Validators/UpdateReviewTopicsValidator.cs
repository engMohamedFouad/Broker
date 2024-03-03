using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Validators
{
    public class UpdateReviewTopicsValidator : AbstractValidator<UpdateReviewTopicsCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IReviewTopicService _reviewTopicService;
        #endregion

        #region Constructors
        public UpdateReviewTopicsValidator(IStringLocalizer<SharedResources> localizer, IReviewTopicService reviewTopicService)
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
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
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
            .MustAsync(async (model, Key, CancellationToken) => !await _reviewTopicService.IsNameArExistExcludeSelf(Key, model.Id))
            .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DescriptionEn)
              .MustAsync(async (model, Key, CancellationToken) => !await _reviewTopicService.IsNameEnExistExcludeSelf(Key, model.Id))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


