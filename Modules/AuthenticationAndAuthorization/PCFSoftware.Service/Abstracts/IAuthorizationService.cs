using Broker.AuthenticationAndAuthorization.Data.DTOs;
using Broker.AuthenticationAndAuthorization.Data.Requests;
using Broker.AuthenticationAndAuthorization.Data.Results;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        public Task<string> EditRoleAsync(EditRoleRequest request);
        public Task<string> DeleteRoleAsync(int roleId);
        public Task<bool> IsRoleExistById(int roleId);
        public Task<List<Role>> GetRolesList();
        public Task<Role> GetRoleById(int id);
        public Task<ManageUserRolesResult> ManageUserRolesData(User user);
        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);
        public Task<ManageUserClaimsResult> ManageUserClaimData(User user);
        public Task<ManageRoleClaimsResult> ManageRoleClaimData(Role role);
        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
        public Task<string> UpdateRoleClaims(UpdateRoleClaimsRequest request);
    }
}
