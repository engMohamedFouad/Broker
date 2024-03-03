using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Procedures
{
    public partial class ProcedureProfile : Profile
    {
        public ProcedureProfile()
        {
            AddProcedureMapping();
            UpdateProcedureMapping();
            GetProcedurePaginationMapping();
            GetProcedureByIdMapping();
        }
    }
}
