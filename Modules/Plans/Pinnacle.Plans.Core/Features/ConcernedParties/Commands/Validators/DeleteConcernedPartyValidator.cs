using FluentValidation;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Resources;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Validators
{
    public class DeleteConcernedPartyValidator : AbstractValidator<DeleteConcernedPartiesCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IConcernedPartyService _concernedPartyService;
        #endregion

        #region Constructors
        public DeleteConcernedPartyValidator(IStringLocalizer<SharedResources> localizer, IConcernedPartyService concernedPartyService)
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
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (Key, CancellationToken) => !await _concernedPartyService.HasManagement(Key))
                .WithMessage(_localizer[SharedResourcesKeys.HasManagement]);
        }

        #endregion
    }
}
