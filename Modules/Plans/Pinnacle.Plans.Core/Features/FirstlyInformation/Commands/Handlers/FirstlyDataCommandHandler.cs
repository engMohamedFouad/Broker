using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Handlers
{
    public class FirstlyDataCommandHandler : ResponseHandler,
        IRequestHandler<AddFirstlyDataCommand, Response<string>>,
        IRequestHandler<UpdateFirstlyDataCommand, Response<string>>,
        IRequestHandler<DeleteFirstlyDataCommand, Response<string>>
    {
        #region Fields
        private readonly IFirstlyInformationService _firstlyInformationService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public FirstlyDataCommandHandler(IFirstlyInformationService firstlyInformationService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _firstlyInformationService=firstlyInformationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddFirstlyDataCommand request, CancellationToken cancellationToken)
        {
            var firstlyData = _mapper.Map<FirstlyData>(request);
            var result = await _firstlyInformationService.AddFirstlyDataAsync(firstlyData);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateFirstlyDataCommand request, CancellationToken cancellationToken)
        {
            var firstlyData = await _firstlyInformationService.GetById(request.Id);
            if (firstlyData == null) return NotFound<string>();
            var mapper = _mapper.Map(request, firstlyData);
            var result = await _firstlyInformationService.UpdateFirstlyDataAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteFirstlyDataCommand request, CancellationToken cancellationToken)
        {
            var firstlyData = await _firstlyInformationService.GetById(request.Id);
            if (firstlyData == null) return NotFound<string>();
            var result = await _firstlyInformationService.DeleteFirstlyDataAsync(firstlyData);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }
        #endregion
    }
}
