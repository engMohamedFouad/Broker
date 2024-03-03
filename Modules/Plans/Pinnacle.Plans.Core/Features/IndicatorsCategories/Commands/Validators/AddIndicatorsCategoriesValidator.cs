﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Validators
{
    public class AddIndicatorsCategoriesValidator : AbstractValidator<AddIndicatorsCategoriesCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IIndicatorsCategoryService _indicatorsCategoryService;
        #endregion

        #region Constructors
        public AddIndicatorsCategoriesValidator(IStringLocalizer<SharedResources> localizer,
                                                IIndicatorsCategoryService indicatorsCategoryService)
        {
            _indicatorsCategoryService = indicatorsCategoryService;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {

            RuleFor(x => x.NameAr)
               .MustAsync(async (Key, CancellationToken) => !await _indicatorsCategoryService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameEn)
              .MustAsync(async (Key, CancellationToken) => !await _indicatorsCategoryService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}

