using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Validators
{
    public class DeleteFirstlyDataValidator : AbstractValidator<DeleteFirstlyDataCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public DeleteFirstlyDataValidator(IStringLocalizer<SharedResources> localizer)
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