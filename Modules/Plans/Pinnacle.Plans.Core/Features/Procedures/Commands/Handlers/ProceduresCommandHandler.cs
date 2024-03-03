using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Procedures.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Procedures.Commands.Handlers
{
    public class ProceduresCommandHandler : ResponseHandler,
        IRequestHandler<AddProcedureCommand, Response<string>>,
        IRequestHandler<UpdateProcedureCommand, Response<string>>,
        IRequestHandler<DeleteProcedureCommand, Response<string>>
    {
        #region Fields
        private readonly IProcedureService _procedureService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ProceduresCommandHandler(IProcedureService ProcedureService,
                                        IMapper mapper,
                                        IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _procedureService = ProcedureService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddProcedureCommand request, CancellationToken cancellationToken)
        {
            var procedure = _mapper.Map<Procedure>(request);
            var result = await _procedureService.AddProcedureAsync(procedure, request.IndicatorId, request.PlanId);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateProcedureCommand request, CancellationToken cancellationToken)
        {
            var procedure = await _procedureService.GetById(request.Id);
            if (procedure == null) return NotFound<string>();
            var mapper = _mapper.Map(request, procedure);
            var result = await _procedureService.UpdateProcedureAsync(mapper);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteProcedureCommand request, CancellationToken cancellationToken)
        {
            var procedure = await _procedureService.GetById(request.Id);
            if (procedure == null) return NotFound<string>();
            var result = await _procedureService.DeleteProcedureAsync(procedure);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}
