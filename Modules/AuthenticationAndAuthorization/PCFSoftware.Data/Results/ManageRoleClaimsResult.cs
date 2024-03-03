namespace Broker.AuthenticationAndAuthorization.Data.Results
{
    public class ManageRoleClaimsResult
    {
        public int RoleId { get; set; }
        public List<RoleClaims> roleClaims { get; set; }
    }
    public class RoleClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
