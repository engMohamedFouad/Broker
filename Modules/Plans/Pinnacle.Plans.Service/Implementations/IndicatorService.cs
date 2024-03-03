using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Entities.Identity;
using Pinnacle.Data.Enums;
using Pinnacle.Infrastructure.Builders.AuthServices.Interfaces;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class IndicatorService : IIndicatorService
    {
        #region Fields
        private readonly IIndicatorsRepository _indicatorsRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _imapper;
        private readonly ISystemLogService _systemLogService;
        private readonly ICurrentUserService _currentUserService;
        private int userId;
        // private readonly IFileService _fileService;
        #endregion
        #region Constructors
        public IndicatorService(IIndicatorsRepository indicatorsRepository,
                                UserManager<User> userManager,
                                IMapper imapper,
                                ISystemLogService systemLogService,
                                ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _indicatorsRepository = indicatorsRepository;
            _userManager = userManager;
            _imapper = imapper;
            _systemLogService = systemLogService;
            userId = _currentUserService.GetUserId();
            //  _fileService=fileService;

        }

        #endregion
        #region Handle Functions
        public async Task<bool> AddIndicatorAsync(Indicator indicator)
        {
            try
            {
                await _indicatorsRepository.AddAsync(indicator);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    UserId = userId,
                    ItemId = indicator.Id,
                    TableAr = "مؤشر",
                    TableEn = "Indicator",
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteIndicatorAsync(Indicator indicator)
        {
            try
            {
                await _indicatorsRepository.DeleteAsync(indicator);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    UserId = userId,
                    ItemId = indicator.Id,
                    TableAr = "مؤشر",
                    TableEn = "Indicator",
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Indicator> GetAll()
        {
            return _indicatorsRepository.GetTableNoTracking();
        }

        public async Task<Indicator> GetById(int id)
        {
            return await _indicatorsRepository.GetByIdAsync(id);
        }

        public async Task<GetIndicatorByIdDTO> GetIndicatorAndDetailsAsync(int id)
        {
            //Review::ToDo Part Of procedures
            //We include files instead of user because user is only one not collection
            var indicator = await GetAll()
                                 .FirstOrDefaultAsync(x => x.Id == id);
            var mapper = _imapper.Map<GetIndicatorByIdDTO>(indicator);

            User? preparedByIdUser = null;
            User? updatedByIdUser = null;
            User? reviewedByIdUser = null;
            User? adoptedByIdUser = null;
            //Get The Users Name Of indicator
            if (mapper != null)
            {
                if (mapper.PreparedById != null)
                    preparedByIdUser = await _userManager.FindByIdAsync(mapper.PreparedById.ToString());
                if (mapper.UpdatedById != null)
                    updatedByIdUser = await _userManager.FindByIdAsync(mapper.UpdatedById.ToString());
                if (mapper.ReviewedById != null)
                    reviewedByIdUser = await _userManager.FindByIdAsync(mapper.ReviewedById.ToString());
                if (mapper.AdoptedById != null)
                    adoptedByIdUser = await _userManager.FindByIdAsync(mapper.AdoptedById.ToString());

                if (preparedByIdUser != null)
                    mapper.PreparedBy = preparedByIdUser.UserName;
                if (updatedByIdUser != null)
                    mapper.UpdatedBy = updatedByIdUser.UserName;
                if (reviewedByIdUser != null)
                    mapper.ReviewedBy = reviewedByIdUser.UserName;
                if (adoptedByIdUser != null)
                    mapper.AdoptedBy = adoptedByIdUser.UserName;

                foreach (var item in mapper.IndicatorDetails)
                {
                    var user = await _userManager.FindByIdAsync(item.UserId.ToString());
                    if (user != null)
                        item.UserName = user.UserName;
                }
            }
            return mapper;
        }

        public IQueryable<Indicator> GetIndicatorsQuery(string? filter)
        {
            var indicators = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                indicators = indicators.Where(x => x.NameAr.Contains(filter) ||
                                                 x.NameEn.Contains(filter) ||
                                                 x.Id.ToString().Contains(filter));
            }
            return indicators.OrderByDescending(x => x.Id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _indicatorsRepository.GetTableNoTracking().AnyAsync(x => x.Id == id);
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            return await GetAll().AnyAsync(x => x.NameAr == nameAr);
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            return await GetAll().AnyAsync(x => x.NameAr == nameAr && x.Id != id);
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            return await GetAll().AnyAsync(x => x.NameEn == nameEn);
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            return await GetAll().AnyAsync(x => x.NameEn == nameEn && x.Id != id);
        }

        public async Task<bool> UpdateIndicatorAsync(Indicator indicator)
        {
            try
            {
                await _indicatorsRepository.UpdateAsync(indicator);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    UserId = userId,
                    ItemId = indicator.Id,
                    TableAr = "مؤشر",
                    TableEn = "Indicator",
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
