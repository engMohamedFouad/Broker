using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Validators
{
    public class UpdateIndicatorValidator : AbstractValidator<UpdateIndicatorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IIndicatorService _indicatorService;
        #endregion

        #region Constructors
        public UpdateIndicatorValidator(IStringLocalizer<SharedResources> localizer,
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
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
              .MustAsync(async (model, Key, CancellationToken) => !await _indicatorService.IsNameArExistExcludeSelf(Key, model.Id))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
              .MustAsync(async (model, Key, CancellationToken) => !await _indicatorService.IsNameEnExistExcludeSelf(Key, model.Id))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}

