using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Models;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.AuthenticationAndAuthorization.Service.Abstracts;
using Broker.Core.Bases;
using Broker.Core.Resources;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Handlers
{
    public class ClaimsQueryHandler : ResponseHandler,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>,
        IRequestHandler<ManageRoleClaimsQuery, Response<ManageRoleClaimsResult>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ClaimsQueryHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IAuthorizationService authorizationService,
                                  UserManager<User> userManager,
                                  RoleManager<Role> roleManager) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
            _stringLocalizer = stringLocalizer;
            _roleManager = roleManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null) return NotFound<ManageUserClaimsResult>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
            var result = await _authorizationService.ManageUserClaimData(user);
            return Success(result);
        }

        public async Task<Response<ManageRoleClaimsResult>> Handle(ManageRoleClaimsQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.RoleId.ToString());
            if (role == null) return NotFound<ManageRoleClaimsResult>(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
            var result = await _authorizationService.ManageRoleClaimData(role);
            return Success(result);
        }
        #endregion
    }
}
