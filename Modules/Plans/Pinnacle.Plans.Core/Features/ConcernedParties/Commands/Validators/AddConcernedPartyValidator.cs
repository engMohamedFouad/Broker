using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Validators
{
    public class AddConcernedPartyValidator : AbstractValidator<AddConcernedPartiesCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IConcernedPartyService _concernedPartyService;
        #endregion

        #region Constructors
        public AddConcernedPartyValidator(IStringLocalizer<SharedResources> localizer, IConcernedPartyService concernedPartyService)
        {
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
            RuleFor(x => x.PartyType)
               .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ManagerName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.TradingNumber)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.TaxNumber)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
               .MustAsync(async (Key, CancellationToken) => !await _concernedPartyService.IsNameArExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameEn)
              .MustAsync(async (Key, CancellationToken) => !await _concernedPartyService.IsNameEnExist(Key))
              .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
        }

        #endregion
    }
}
