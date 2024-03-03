using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Handlers
{
    public class ConcernedPartiesCommandHandler : ResponseHandler,
        IRequestHandler<AddConcernedPartiesCommand, Response<string>>,
        IRequestHandler<UpdateConcernedPartiesCommand, Response<string>>,
        IRequestHandler<DeleteConcernedPartiesCommand, Response<string>>
    {
        #region Fields
        private readonly IConcernedPartyService _concernedPartyService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ConcernedPartiesCommandHandler(IConcernedPartyService concernedPartyService,
                                            IMapper mapper,
                                            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _concernedPartyService = concernedPartyService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddConcernedPartiesCommand request, CancellationToken cancellationToken)
        {
            var concernedParty = _mapper.Map<ConcernedParty>(request);
            var result = await _concernedPartyService.AddConcernedPartyAsync(concernedParty, request.PhoneNumbers, request.BranchNames);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.AddFailed]);
            }
            return Created("");
        }

        public async Task<Response<string>> Handle(UpdateConcernedPartiesCommand request, CancellationToken cancellationToken)
        {
            var concernedParty = await _concernedPartyService.GetByIdWithoutIncluding(request.Id);
            if (concernedParty == null) return NotFound<string>();
            var mapper = _mapper.Map(request, concernedParty);
            var result = await _concernedPartyService.UpdateConcernedPartyAsync(mapper, request.PhoneNumbers, request.BranchNames);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
            }
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteConcernedPartiesCommand request, CancellationToken cancellationToken)
        {
            var concernedParty = await _concernedPartyService.GetById(request.Id);
            if (concernedParty == null) return NotFound<string>();
            var result = await _concernedPartyService.DeleteConcernedPartyAsync(concernedParty);
            if (result == false)
            {
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.DeletedFailed]);
            }
            return Success("");
        }

        #endregion
    }
}

