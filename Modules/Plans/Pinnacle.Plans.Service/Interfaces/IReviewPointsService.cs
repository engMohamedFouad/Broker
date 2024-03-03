using Microsoft.AspNetCore.Http;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IReviewPointsService
    {
        public IQueryable<ReviewPoints> GetReviewPointsQuery(string search);
        public Task<ReviewPoints> GetReviewPointsById(int id);
        public List<PointFilesDTO> CompleteDomainForImage(List<PointFilesDTO>? pointFilesDTOs);
        public Task<string> AddReviewPointsAsync(ReviewPoints reviewPoints, List<IFormFile>? reviewPointsFiles, List<int> assignedUsers);
        public Task<string> DeleteReviewPointsAsync(ReviewPoints reviewPoints);
        public Task<string> UpdateReviewPointsAsync(ReviewPoints reviewPoints, List<IFormFile>? reviewPointsFiles, List<int> assignedUsers);
        public Task<bool> IsExist(int id);
    }
}
