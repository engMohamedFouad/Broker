﻿using MediatR;
using Microsoft.Extensions.Localization;
using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Models;
using Broker.AuthenticationAndAuthorization.Service.Abstracts;
using Broker.Core.Bases;
using Broker.Core.Resources;

namespace Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimsCommandHandler : ResponseHandler,
         IRequestHandler<UpdateUserClaimsCommand, Response<string>>,
         IRequestHandler<UpdateRoleClaimsCommand, Response<string>>
    {
        #region Fileds
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;

        #endregion
        #region Constructors
        public ClaimsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                    IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _authorizationService = authorizationService;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateUserClaims(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserIsNotFound]);
                case "FailedToRemoveOldClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldClaims]);
                case "FailedToAddNewClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewClaims]);
                case "FailedToUpdateClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateClaims]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }

        public async Task<Response<string>> Handle(UpdateRoleClaimsCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.UpdateRoleClaims(request);
            switch (result)
            {
                case "RoleIsNull": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.RoleNotExist]);
                case "FailedToRemoveOldClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldClaims]);
                case "FailedToAddNewClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewClaims]);
                case "FailedToUpdateClaims": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToUpdateClaims]);
            }
            return Success<string>(_stringLocalizer[SharedResourcesKeys.Success]);
        }
        #endregion
    }
}
