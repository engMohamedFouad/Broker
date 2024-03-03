using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Indicators.Commands.Handlers
{
    public class IndicatorCommandHandler : ResponseHandler,
        IRequestHandler<AddIndicatorCommand, Response<string>>,
        IRequestHandler<UpdateIndicatorCommand, Response<string>>,
        IRequestHandler<DeleteIndicatorCommand, Response<string>>
    {
        #region Fields
        private readonly IIndicatorService _indicatorService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public IndicatorCommandHandler(IIndicatorService indicatorService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _indicatorService = indicatorService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddIndicatorCommand request, CancellationToken cancellationToken)
        {
            var indicator = _mapper.Map<Indicator>(request);
            var result = await _indicatorService.AddIndicatorAsync(indicator);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateIndicatorCommand request, CancellationToken cancellationToken)
        {
            var indicator = await _indicatorService.GetById(request.Id);
            if (indicator == null) return NotFound<string>();
            var mapper = _mapper.Map(request, indicator);
            var result = await _indicatorService.UpdateIndicatorAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteIndicatorCommand request, CancellationToken cancellationToken)
        {
            var indicator = await _indicatorService.GetById(request.Id);
            if (indicator == null) return NotFound<string>();
            var result = await _indicatorService.DeleteIndicatorAsync(indicator);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}