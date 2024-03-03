using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Models;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Handlers
{
    public class IndicatorsCategoriesQueryHandler : ResponseHandler,
        IRequestHandler<GetIndicatorsCategoriesPaginationQuery, PaginatedResult<GetIndicatorsCategoriesPaginationResult>>,
        IRequestHandler<GetIndicatorsCategoriesByIdQuery, Response<GetIndicatorsCategoriesByIdResult>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IIndicatorsCategoryService _indicatorsCategoryService;
        #endregion
        #region Constructors
        public IndicatorsCategoriesQueryHandler(IMapper mapper,
                                                IStringLocalizer<SharedResources> stringLocalizer,
                                                IIndicatorsCategoryService indicatorsCategoryService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _indicatorsCategoryService = indicatorsCategoryService;
        }

        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetIndicatorsCategoriesPaginationResult>> Handle(GetIndicatorsCategoriesPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _indicatorsCategoryService.GetIndicatorsCategorysQuery(request.Search);
            var result = await _mapper.ProjectTo<GetIndicatorsCategoriesPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetIndicatorsCategoriesByIdResult>> Handle(GetIndicatorsCategoriesByIdQuery request, CancellationToken cancellationToken)
        {
            var indicator = await _indicatorsCategoryService.GetById(request.Id);
            if (indicator == null) return NotFound<GetIndicatorsCategoriesByIdResult>();
            var result = await _indicatorsCategoryService.GetById(request.Id);
            var mapper = _mapper.Map<GetIndicatorsCategoriesByIdResult>(result);
            return Success(mapper);
        }


        #endregion
    }
}

