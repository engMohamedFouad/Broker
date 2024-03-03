using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Handlers
{
    public class ProcedureDetailsCommandHandler : ResponseHandler,
        IRequestHandler<AddProcedureDetailsCommand, Response<string>>,
        IRequestHandler<UpdateProcedureDetailsCommand, Response<string>>,
        IRequestHandler<DeleteProcedureDetailsCommand, Response<string>>
    {
        #region Fields
        private readonly IProcedureDetailsService _procedureDetailsService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ProcedureDetailsCommandHandler(IProcedureDetailsService procedureDetailsService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _procedureDetailsService = procedureDetailsService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddProcedureDetailsCommand request, CancellationToken cancellationToken)
        {
            var ProcedureDetails = _mapper.Map<ProcedureDetails>(request);
            var result = await _procedureDetailsService.AddProcedureDetailsAsync(ProcedureDetails, request.Files);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateProcedureDetailsCommand request, CancellationToken cancellationToken)
        {
            var ProcedureDetails = await _procedureDetailsService.GetByIdAsync(request.Id);
            if (ProcedureDetails == null) return NotFound<string>();
            var mapper = _mapper.Map(request, ProcedureDetails);
            var result = await _procedureDetailsService.UpdateProcedureDetailsAsync(mapper, request.Files);
            switch (result)
            {
                case "FailedToUploadFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUploadFiles]);
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(DeleteProcedureDetailsCommand request, CancellationToken cancellationToken)
        {
            var ProcedureDetails = await _procedureDetailsService.GetByIdAsync(request.Id);
            if (ProcedureDetails == null) return NotFound<string>();
            var result = await _procedureDetailsService.DeleteProcedureDetailsAsync(ProcedureDetails);
            switch (result)
            {
                case "FaliedToDeletePhysialFiles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FaliedToDeletePhysialFiles]);
                case "Failed": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        #endregion
    }
}