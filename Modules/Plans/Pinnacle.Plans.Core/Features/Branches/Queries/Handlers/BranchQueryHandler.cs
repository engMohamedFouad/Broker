using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Branches.Queries.Models;
using Pinnacle.Plans.Core.Features.Branches.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Branches.Queries.Handlers
{
    public class BranchQueryHandler : ResponseHandler,
        IRequestHandler<GetBranchesByConcernedPartyQuery, PaginatedResult<GetBranchesByConcernedPartyResult>>
    {
        #region Fields
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public BranchQueryHandler(IBranchService branchService,
                                  IMapper mapper,
                                  IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _branchService = branchService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetBranchesByConcernedPartyResult>> Handle(GetBranchesByConcernedPartyQuery request, CancellationToken cancellationToken)
        {
            var query = _branchService.GetBranchesbyConcernedParty(request.Search, request.ConcernedPartyId);
            var result = await _mapper.ProjectTo<GetBranchesByConcernedPartyResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }
        #endregion
    }
}