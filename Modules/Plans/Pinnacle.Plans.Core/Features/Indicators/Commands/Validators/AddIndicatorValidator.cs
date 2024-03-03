using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Validators
{
    public class AddIndicatorValidator : AbstractValidator<AddIndicatorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IIndicatorService _indicatorService;
        #endregion

        #region Constructors
        public AddIndicatorValidator(IStringLocalizer<SharedResources> localizer,
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
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
               .MustAsync(async (Key, CancellationToken) => !await _indicatorService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
              .MustAsync(async (Key, CancellationToken) => !await _indicatorService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


