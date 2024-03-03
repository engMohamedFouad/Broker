using Broker.AuthenticationAndAuthorization.Core.Features.ApplicationUser.Commands.Models;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}