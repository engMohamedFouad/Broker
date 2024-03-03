using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ConcernedPartyService : IConcernedPartyService
    {
        #region Fields
        private readonly IConcernedPartyRepository _concernedPartyRepository;
        private readonly IManagementService _managementService;
        private readonly IPhoneNumbersRepository _phoneNumbersRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly IBranchRepository _branchRepository;
        #endregion
        #region Constructors
        public ConcernedPartyService(IConcernedPartyRepository concernedPartyRepository,
                                     IManagementService managementService,
                                     IPhoneNumbersRepository phoneNumbersRepository,
                                     ISystemLogService systemLogService,
                                     IBranchRepository branchRepository)
        {
            _concernedPartyRepository = concernedPartyRepository;
            _managementService = managementService;
            _phoneNumbersRepository = phoneNumbersRepository;
            _systemLogService = systemLogService;
            _branchRepository = branchRepository;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddConcernedPartyAsync(ConcernedParty concernedParty, List<string> phoneNumbers, List<string>? branchNames)
        {
            var trans = await _concernedPartyRepository.BeginTransactionAsync();
            try
            {
                //Added Concerned Party
                concernedParty.Id = await GetMaxIdAsync();
                await _concernedPartyRepository.AddAsync(concernedParty);

                //We will Added Branch This to take id of branch and added it with concerned
                //this is as Transition 
                var branchList = new List<Branch>();
                if (branchNames != null && branchNames.Count() > 0)
                {
                    foreach (var branch in branchNames)
                    {
                        branchList.Add(new Branch() { NameAr = branch, NameEn = branch, ConcernedPartyId = concernedParty.Id });
                    }
                    await _branchRepository.AddRangeAsync(branchList);
                }


                var phoneList = new List<PhoneNumber>();

                foreach (var phoneNumber in phoneNumbers)
                {
                    var phone = new PhoneNumber
                    {
                        Number = phoneNumber,
                        PartyId = concernedParty.Id
                    };
                    phoneList.Add(phone);
                };

                await _phoneNumbersRepository.AddRangeAsync(phoneList);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = concernedParty.Id,
                    TableAr = "جهة",
                    TableEn = "Concerned Party",
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

        public async Task<bool> DeleteConcernedPartyAsync(ConcernedParty concernedParty)
        {
            var trans = await _concernedPartyRepository.BeginTransactionAsync();
            try
            {
                await _concernedPartyRepository.DeleteAsync(concernedParty);
                //delete also the branches 
                var branches = await _branchRepository.GetTableNoTracking().Where(x => x.ConcernedPartyId == concernedParty.Id).ToListAsync();
                if (branches.Any())
                {
                    await _branchRepository.DeleteRangeAsync(branches);
                }

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = concernedParty.Id,
                    TableAr = "جهة",
                    TableEn = "Concerned Party",
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

        public IQueryable<ConcernedParty> GetAll()
        {
            return _concernedPartyRepository.GetTableNoTracking();
        }

        public async Task<ConcernedParty> GetById(int id)
        {
            return await _concernedPartyRepository.GetTableNoTracking()
                                                  .Include(x => x.BranchesNavigations)
                                                  .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ConcernedParty> GetByIdWithoutIncluding(int id)
        {
            return await _concernedPartyRepository.GetByIdAsync(id);
        }

        public IQueryable<ConcernedParty> GetConcernedPartiesQuery(string? filter)
        {
            var concernedParties = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                concernedParties = concernedParties.Where(x => x.NameAr.Contains(filter) ||
                                                           x.NameEn.Contains(filter) ||
                                                           x.Id.ToString().Contains(filter));
            }
            return concernedParties.OrderByDescending(x => x.Id);
        }

        public async Task<int> GetMaxIdAsync()
        {
            if (GetAll().Any())
            {
                return await GetAll().MaxAsync(x => x.Id) + 1;
            }
            return 1;
        }

        public async Task<List<string>> GetPhoneNumbers(int id)
        {
            //get the concerned Party Numbers
            var numbers = await _phoneNumbersRepository.GetTableNoTracking().Where(x => x.PartyId == id).ToListAsync();
            if (numbers.Any())
            {
                return numbers.Select(x => x.Number).ToList();
            }
            return [];
        }

        public async Task<bool> HasManagement(int id)
        {
            return await _managementService.GetAll().AnyAsync(x => x.PartyId == id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _concernedPartyRepository.GetTableNoTracking().AnyAsync(x => x.Id == id);
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

        public async Task<bool> UpdateConcernedPartyAsync(ConcernedParty concernedParty, List<string> phoneNumbers, List<string>? branchNames)
        {
            var trans = await _concernedPartyRepository.BeginTransactionAsync();
            try
            {
                await _concernedPartyRepository.UpdateAsync(concernedParty);
                //get the concerned Party Numbers
                var numbers = await _phoneNumbersRepository.GetTableNoTracking().Where(x => x.PartyId == concernedParty.Id).ToListAsync();
                //Delete all the numbers
                await _phoneNumbersRepository.DeleteRangeAsync(numbers);
                //delete also the branches 
                var branches = await _branchRepository.GetTableNoTracking().Where(x => x.ConcernedPartyId == concernedParty.Id).ToListAsync();
                if (branches.Any())
                {
                    await _branchRepository.DeleteRangeAsync(branches);
                }

                //We will Added Branch This to take id of branch and added it with concerned
                //this is as Transition 
                var branchList = new List<Branch>();
                if (branchNames != null && branchNames.Count() > 0)
                {
                    foreach (var branch in branchNames)
                    {
                        branchList.Add(new Branch() { NameAr = branch, NameEn = branch, ConcernedPartyId = concernedParty.Id });
                    }
                    await _branchRepository.AddRangeAsync(branchList);
                }

                //Added New Numbers
                var phoneList = new List<PhoneNumber>();

                Parallel.ForEach(phoneNumbers, phoneNumber =>
                {
                    var phone = new PhoneNumber
                    {
                        Number = phoneNumber,
                        PartyId = concernedParty.Id
                    };
                    phoneList.Add(phone);
                });

                await _phoneNumbersRepository.AddRangeAsync(phoneList);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = concernedParty.Id,
                    TableAr = "جهة",
                    TableEn = "Concerned Party",
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
        #endregion
    }
}
