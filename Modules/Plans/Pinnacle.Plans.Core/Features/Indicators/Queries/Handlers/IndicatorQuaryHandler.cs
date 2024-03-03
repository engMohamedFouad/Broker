using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Indicators.Queries.Models;
using Pinnacle.Plans.Core.Features.Indicators.Queries.Results;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Indicators.Queries.Handlers
{
    public class IndicatorQuaryHandler : ResponseHandler,
        IRequestHandler<GetIndicatorPaginationQuary, PaginatedResult<GetIndicatorPaginationResult>>,
        IRequestHandler<GetIndicatorByIdQuery, Response<GetIndicatorByIdDTO>>
    {
        #region Fields
        private readonly IIndicatorService _indicatorService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public IndicatorQuaryHandler(IIndicatorService indicatorService,
                                     IMapper mapper,
                                     IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _indicatorService = indicatorService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }



        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetIndicatorPaginationResult>> Handle(GetIndicatorPaginationQuary request, CancellationToken cancellationToken)
        {
            var query = _indicatorService.GetIndicatorsQuery(request.Search);
            var result = await _mapper.ProjectTo<GetIndicatorPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetIndicatorByIdDTO>> Handle(GetIndicatorByIdQuery request, CancellationToken cancellationToken)
        {
            var indicator = await _indicatorService.GetById(request.Id);
            if (indicator == null) return NotFound<GetIndicatorByIdDTO>();
            var result = await _indicatorService.GetIndicatorAndDetailsAsync(request.Id);
            return Success(result);
        }
        #endregion
    }
}
