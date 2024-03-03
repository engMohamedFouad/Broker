using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Data.DTOs;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class PlanService : IPlanService
    {
        #region Fields
        private readonly IPlanRepository _planRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly IYearlyPlanBranchRepository _yearlyPlanBranchRepository;
        private readonly IMapper _mapper;
        private const int manager = 1;
        private const int user = 0;
        #endregion
        #region Constructors
        public PlanService(IPlanRepository planRepository,
                           ISystemLogService systemLogService,
                           IYearlyPlanBranchRepository yearlyPlanBranchRepository,
                           IMapper mapper)
        {
            _planRepository = planRepository;
            _systemLogService = systemLogService;
            _yearlyPlanBranchRepository = yearlyPlanBranchRepository;
            _mapper = mapper;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddYearlyPlanAsync(YearlyPlan yearlyPlan, List<AddUserManagersDTO> userManagers)
        {
            var trans = await _planRepository.BeginTransactionAsync();
            try
            {
                foreach (var item in userManagers)
                {
                    if (!yearlyPlan.YearlyPlanUsersNavigations.Any(x => x.UId == item.Id))
                    {
                        yearlyPlan.YearlyPlanUsersNavigations.Add(new YearlyPlanUsers { UId = item.Id, YPId = yearlyPlan.Id, Type = manager });
                    }
                }
                await _planRepository.AddAsync(yearlyPlan);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = yearlyPlan.Id,
                    TableAr = "خطة سنوية",
                    TableEn = "yearly Plan",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteYearlyPlanAsync(YearlyPlan yearlyPlan)
        {
            var trans = await _planRepository.BeginTransactionAsync();
            try
            {
                //Delete all branches Relations
                var branches = await _yearlyPlanBranchRepository.GetTableNoTracking().Where(x => x.YPId == yearlyPlan.Id).ToListAsync();
                if (branches.Any())
                {
                    await _yearlyPlanBranchRepository.DeleteRangeAsync(branches);
                }
                //delete Plan And All Tables Relations
                await _planRepository.ExecSQLAsync($"Delete From YearlyPlanFirstlyData where YPId={yearlyPlan.Id} Delete From YearlyPlanManagement where YPId={yearlyPlan.Id} Delete From YearlyPlanReview where YPId={yearlyPlan.Id} Delete From YearlyPlanReviewTopic where YPId={yearlyPlan.Id} Delete From YearlyPlanUsers where YPId={yearlyPlan.Id} Delete From YearlyPlan where Id={yearlyPlan.Id}");

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = yearlyPlan.Id,
                    TableAr = "خطة سنوية",
                    TableEn = "yearly Plan",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public IQueryable<YearlyPlan> GetAll()
        {
            return _planRepository.GetTableNoTracking();
        }

        public async Task<YearlyPlan> GetById(int id)
        {
            return await _planRepository.GetTableNoTracking()
                                        .Include(x => x.ConcernedPartyNavigation)
                                        .Include(x => x.YearlyPlanManagementsNavigations).ThenInclude(x => x.ManagementNavigation)
                                        .Include(x => x.YearlyPlanUsersNavigations).ThenInclude(x => x.UserNavigation)
                                        .Include(x => x.YearlyPlanReviewTopicsNavigations).ThenInclude(x => x.ReviewTopicNavigation)
                                        .Include(x => x.YearlyPlanReviewsNavigations).ThenInclude(x => x.ReviewNavigation)
                                        .Include(x => x.YearlyPlanFirstlyDatasNavigations).ThenInclude(x => x.FirstlyDataNavigation)
                                        .Include(x => x.YearlyPlanBranchNavigations).ThenInclude(x => x.BranchNavigation)
                                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<YearlyPlan> GetByIdWithoutInclude(int id)
        {
            return await _planRepository.GetByIdAsync(id);
        }

        public IQueryable<YearlyPlan> GetyearlyPlansQuery(string? year, string? concernedParty, string? employeeName, bool status)
        {
            var yearlyPlans = GetAll().Include(x => x.ConcernedPartyNavigation)
                                      .Include(x => x.YearlyPlanUsersNavigations).ThenInclude(x => x.UserNavigation)
                                      .AsQueryable();
            if (year != null)
                yearlyPlans = yearlyPlans.Where(x => x.Year == year);
            if (concernedParty != null)
                yearlyPlans = yearlyPlans.Where(x => x.ConcernedPartyNavigation.NameAr == concernedParty || x.ConcernedPartyNavigation.NameEn == concernedParty);
            if (employeeName != null)
                yearlyPlans = yearlyPlans.Where(x => x.YearlyPlanUsersNavigations.Any(x => x.UserNavigation.UserName == employeeName));

            return yearlyPlans.OrderByDescending(x => x.Id);
        }

        public async Task<bool> UpdateYearlyPlanAsync(YearlyPlan yearlyPlan, AddPlansDTO addPlansDTO)
        {
            var trans = await _planRepository.BeginTransactionAsync();
            try
            {
                //Delete all branches Relations
                var branches = await _yearlyPlanBranchRepository.GetTableNoTracking().Where(x => x.YPId == yearlyPlan.Id).ToListAsync();
                if (branches.Any())
                {
                    await _yearlyPlanBranchRepository.DeleteRangeAsync(branches);
                }
                //First delete all yearly Plans And Tables
                await _planRepository.ExecSQLAsync($"Delete From YearlyPlanFirstlyData where YPId={yearlyPlan.Id} Delete From YearlyPlanManagement where YPId={yearlyPlan.Id} Delete From YearlyPlanReview where YPId={yearlyPlan.Id} Delete From YearlyPlanReviewTopic where YPId={yearlyPlan.Id} Delete From YearlyPlanUsers where YPId={yearlyPlan.Id} Delete From YearlyPlan where Id={yearlyPlan.Id}");


                //remove dependency To avoid dublicate adding of ConcernedParty
                yearlyPlan.ConcernedPartyNavigation = null;
                if (addPlansDTO.UsersManagers != null)
                {
                    //Added Data As You first Adding
                    foreach (var item in addPlansDTO.UsersManagers)
                    {
                        if (!yearlyPlan.YearlyPlanUsersNavigations.Any(x => x.UId == item.Id))
                        {
                            yearlyPlan.YearlyPlanUsersNavigations.Add(new YearlyPlanUsers { UId = item.Id, YPId = yearlyPlan.Id, Type = manager });
                        }
                    }
                }

                await _planRepository.AddAsync(yearlyPlan);


                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = yearlyPlan.Id,
                    TableAr = "خطة سنوية",
                    TableEn = "yearly Plan",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async Task<int> GetMaxId()
        {
            if (GetAll().Any())
            {
                return await GetAll().MaxAsync(x => x.Id) + 1;
            }
            return 1;
        }

        public Task<(List<UserManagersDTO>, List<UserDTO>)> CompleteData(YearlyPlan yearlyPlan)
        {
            var managers = yearlyPlan.YearlyPlanUsersNavigations.Where(x => x.Type == manager).Select(x => x.UserNavigation);
            var users = yearlyPlan.YearlyPlanUsersNavigations.Where(x => x.Type == user).Select(x => x.UserNavigation);
            var mangersResult =

        }
        #endregion
    }
}
