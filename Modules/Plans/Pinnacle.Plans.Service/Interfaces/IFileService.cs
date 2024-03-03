using Microsoft.AspNetCore.Http;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.Helpers;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IFileService
    {
        public Task<Files> GetById(int id);
        public Task<string> AddFileAsync(Files file, IFormFile actualFile);
        public Task<string> UpdateFileAsync(Files file, IFormFile actualFile);
        public Task<string> DeleteFileAsync(Files file);
        public IQueryable<Files> GetAllFiles(string filter, int yPId);
        public Task<List<FilesResponse>> UploadImage(string location, List<IFormFile> files);
        public string DeleteFileLocal(List<string> filesUrl);
    }
}
