using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Models;
using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Results;
using Broker.Core.Bases;
using Broker.Core.Resources;
using Broker.Core.Wrappers;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
         IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationReponse>>,
         IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager) : base(stringLocalizer)
        {
            _mapper = mapper;
            _sharedResources = stringLocalizer;
            _userManager= userManager;
        }
        #endregion

        #region Handle Functions
        public async Task<PaginatedResult<GetUserPaginationReponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var paginatedList = await _mapper.ProjectTo<GetUserPaginationReponse>(users)
                                            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id==request.Id);
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user==null) return NotFound<GetUserByIdResponse>(_sharedResources[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
        #endregion
    }
}
