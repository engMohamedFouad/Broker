using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Handlers
{
    public class IndicatorsCategoriesCommandHandler : ResponseHandler,
        IRequestHandler<AddIndicatorsCategoriesCommand, Response<string>>,
        IRequestHandler<UpdateIndicatorsCategoriesCommand, Response<string>>,
        IRequestHandler<DeleteIndicatorsCategoriesCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IIndicatorsCategoryService _indicatorsCategoryService;
        #endregion
        #region Constructors
        public IndicatorsCategoriesCommandHandler(IMapper mapper,
                                                  IStringLocalizer<SharedResources> stringLocalizer,
                                                  IIndicatorsCategoryService indicatorsCategoryService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
            _indicatorsCategoryService = indicatorsCategoryService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddIndicatorsCategoriesCommand request, CancellationToken cancellationToken)
        {
            var indicatorsCategory = _mapper.Map<IndicatorsCategory>(request);
            var result = await _indicatorsCategoryService.AddIndicatorsCategoryAsync(indicatorsCategory);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateIndicatorsCategoriesCommand request, CancellationToken cancellationToken)
        {
            var indicatorCategory = await _indicatorsCategoryService.GetById(request.Id);
            if (indicatorCategory == null) return NotFound<string>();
            var mapper = _mapper.Map(request, indicatorCategory);
            var result = await _indicatorsCategoryService.UpdateIndicatorsCategoryAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteIndicatorsCategoriesCommand request, CancellationToken cancellationToken)
        {
            var indicatorCategory = await _indicatorsCategoryService.GetById(request.Id);
            if (indicatorCategory == null) return NotFound<string>();
            var result = await _indicatorsCategoryService.DeleteIndicatorsCategoryAsync(indicatorCategory);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }
        #endregion
    }
}
