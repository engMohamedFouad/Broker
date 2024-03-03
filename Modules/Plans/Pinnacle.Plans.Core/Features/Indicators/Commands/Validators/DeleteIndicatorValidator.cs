using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Validators
{
    public class DeleteIndicatorValidator : AbstractValidator<DeleteIndicatorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public DeleteIndicatorValidator(IStringLocalizer<SharedResources> localizer)
        {
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

        }
        public void ApplyCustomValidationsRules()
        {

        }
        #endregion
    }
}


