using Microsoft.AspNetCore.Http;

namespace Broker.AuthenticationAndAuthorization.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}
