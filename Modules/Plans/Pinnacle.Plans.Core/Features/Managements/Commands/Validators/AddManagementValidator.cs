using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.Managements.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Managements.Commands.Validators
{
    public class AddManagementValidator : AbstractValidator<AddManagementCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IConcernedPartyService _concernedPartyService;
        private readonly IManagementService _managementService;
        #endregion

        #region Constructors
        public AddManagementValidator(IStringLocalizer<SharedResources> localizer,
                                      IConcernedPartyService concernedPartyService,
                                      IManagementService managementService)
        {
            _managementService=managementService;
            _concernedPartyService = concernedPartyService;
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
            RuleFor(x => x.PartyId)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.PartyId)
                .MustAsync(async (Key, CancellationToken) => await _concernedPartyService.IsExist(Key))
                .WithMessage(_localizer[SharedResourcesKeys.HasManagement]);

            RuleFor(x => x.NameAr)
               .MustAsync(async (Key, CancellationToken) => !await _managementService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameEn)
              .MustAsync(async (Key, CancellationToken) => !await _managementService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }
        #endregion
    }
}

