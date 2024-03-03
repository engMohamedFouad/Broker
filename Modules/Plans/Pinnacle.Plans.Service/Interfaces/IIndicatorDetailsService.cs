//using Microsoft.AspNetCore.Http;
//using Pinnacle.Data.Entities.BasicData;
//using Pinnacle.Plans.Data.DTOs.IndicatorsDetails;

//namespace Pinnacle.Plans.Service.Interfaces
//{
//    public interface IIndicatorDetailsService
//    {
//        public IQueryable<IndicatorDetails> GetAll();
//        public Task<List<IndicatorDetails>> GetIndicatorDetailssQuery(int? indicatorId);
//        public Task<IndicatorDetails> GetById(int id);
//        public Task<string> AddIndicatorDetailsAsync(IndicatorDetails indicatorDetail, List<IFormFile> files);
//        public Task<string> UpdateIndicatorDetailsAsync(IndicatorDetails indicatorDetail, List<IFormFile> files);
//        public Task<string> DeleteIndicatorDetailsAsync(IndicatorDetails indicatorDetail);
//        public Task<bool> IsNameArExist(string nameAr);
//        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
//        public Task<bool> IsNameEnExist(string nameEn);
//        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
//        public Task<List<GetIndicatorDetailsByIndicatorIdResult>> GetUserNameAndAddDomainToFileForResults(List<GetIndicatorDetailsByIndicatorIdResult> results);
//        public Task<GetIndicatorDetailsByIdResult> GetUserNameAndAddDomainToFileOfUser(GetIndicatorDetailsByIdResult result);
//    }
//}
