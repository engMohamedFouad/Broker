using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Validators
{
    public class AddFirstlyDataValidator : AbstractValidator<AddFirstlyDataCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IReviewService _reviewService;
        private readonly IFirstlyInformationService _firstlyInformationService;
        #endregion

        #region Constructors
        public AddFirstlyDataValidator(IStringLocalizer<SharedResources> localizer,
                                       IReviewService reviewService,
                                       IFirstlyInformationService firstlyInformationService)
        {
            _firstlyInformationService=firstlyInformationService;
            _reviewService = reviewService;
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
            RuleFor(x => x.ReviewId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.ReviewId)
                .MustAsync(async (Key, CancellationToken) => await _reviewService.IsExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.ReviewNotFound]);
            RuleFor(x => x.DescriptionAr)
               .MustAsync(async (Key, CancellationToken) => !await _firstlyInformationService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.DescriptionEn)
              .MustAsync(async (Key, CancellationToken) => !await _firstlyInformationService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


