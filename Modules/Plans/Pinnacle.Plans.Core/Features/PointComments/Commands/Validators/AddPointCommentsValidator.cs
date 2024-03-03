﻿using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.PointComments.Commands.Models;

namespace Pinnacle.Plans.Core.Features.PointComments.Commands.Validators
{
    public class AddPointCommentsValidator : AbstractValidator<AddPointCommentsCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public AddPointCommentsValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Content)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }
        public void ApplyCustomValidationsRules()
        {
        }
        #endregion
    }
}
