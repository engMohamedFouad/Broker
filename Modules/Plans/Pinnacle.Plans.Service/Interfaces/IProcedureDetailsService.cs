using Microsoft.AspNetCore.Http;
using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IProcedureDetailsService
    {
        public IQueryable<ProcedureDetails> GetAll();
        public Task<IQueryable<ProcedureDetails>?> GetProcedureDetailsQuery(string search, int planId, int indicatorId);
        public Task<ProcedureDetails> GetByIdAsync(int id);
        public Task<string> AddProcedureDetailsAsync(ProcedureDetails procedureDetail, List<IFormFile> files);
        public Task<string> UpdateProcedureDetailsAsync(ProcedureDetails procedureDetail, List<IFormFile> files);
        public Task<string> DeleteProcedureDetailsAsync(ProcedureDetails procedureDetail);
    }
}
