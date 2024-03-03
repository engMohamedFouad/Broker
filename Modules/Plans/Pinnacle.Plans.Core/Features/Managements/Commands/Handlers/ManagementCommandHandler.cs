using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Managements.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Managements.Queries.Handlers
{
    public class ManagementCommandHandler : ResponseHandler,
        IRequestHandler<AddManagementCommand, Response<string>>,
        IRequestHandler<UpdateManagementCommand, Response<string>>,
        IRequestHandler<DeleteManagementCommand, Response<string>>
    {
        #region Fields
        private readonly IManagementService _managementService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ManagementCommandHandler(IManagementService managementService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _managementService=managementService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddManagementCommand request, CancellationToken cancellationToken)
        {
            var management = _mapper.Map<Management>(request);
            var result = await _managementService.AddManagementAsync(management);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateManagementCommand request, CancellationToken cancellationToken)
        {
            var management = await _managementService.GetById(request.Id);
            if (management == null) return NotFound<string>();
            var mapper = _mapper.Map(request, management);
            var result = await _managementService.UpdateManagementAsync(mapper);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteManagementCommand request, CancellationToken cancellationToken)
        {
            var management = await _managementService.GetById(request.Id);
            if (management == null) return NotFound<string>();
            var result = await _managementService.DeleteManagementAsync(management);
            if (result==false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}
