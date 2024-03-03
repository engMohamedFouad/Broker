using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Plans.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Plans.Commands.Handlers
{
    public class PlansCommandHandler : ResponseHandler,
        IRequestHandler<AddPlansCommand, Response<string>>,
        IRequestHandler<UpdatePlansCommand, Response<string>>,
        IRequestHandler<DeletePlanCommand, Response<string>>
    {
        #region Fields
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public PlansCommandHandler(IPlanService planService,
                                   IMapper mapper,
                                   IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _planService = planService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddPlansCommand request, CancellationToken cancellationToken)
        {
            var yearlyPlan = _mapper.Map<YearlyPlan>(request);
            var result = await _planService.AddYearlyPlanAsync(yearlyPlan, request.UsersManagers);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdatePlansCommand request, CancellationToken cancellationToken)
        {
            var yearlyPlan = await _planService.GetById(request.Id);
            if (yearlyPlan == null) return NotFound<string>();
            var mapper = _mapper.Map(request, yearlyPlan);
            var result = await _planService.UpdateYearlyPlanAsync(mapper, request);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            var yearlyPlan = await _planService.GetByIdWithoutInclude(request.Id);
            if (yearlyPlan == null) return NotFound<string>();
            var result = await _planService.DeleteYearlyPlanAsync(yearlyPlan);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}
