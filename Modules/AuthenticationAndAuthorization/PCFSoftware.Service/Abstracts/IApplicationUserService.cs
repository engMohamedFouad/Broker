using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Service.Abstracts
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
        public Task<bool> IsUserExist(int id);
    }
}
