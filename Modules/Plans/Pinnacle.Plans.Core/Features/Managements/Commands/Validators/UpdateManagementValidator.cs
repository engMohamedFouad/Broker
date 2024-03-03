using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Managements.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Managements.Commands.Validators
{
    public class UpdateManagementValidator : AbstractValidator<UpdateManagementCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IManagementService _managementService;
        #endregion

        #region Constructors
        public UpdateManagementValidator(IStringLocalizer<SharedResources> localizer, IManagementService managementService)
        {
            _managementService = managementService;
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
            RuleFor(x => x.NameAr)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.PartyId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
              .MustAsync(async (model, Key, CancellationToken) => !await _managementService.IsNameArExistExcludeSelf(Key, model.Id))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameEn)
              .MustAsync(async (model, Key, CancellationToken) => !await _managementService.IsNameEnExistExcludeSelf(Key, model.Id))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}


