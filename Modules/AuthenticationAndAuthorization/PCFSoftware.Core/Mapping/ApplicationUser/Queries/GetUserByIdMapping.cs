using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Queries.Results;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
