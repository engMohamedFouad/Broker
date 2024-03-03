using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.ProceduresDetails
{
    public partial class ProcedureDetailsProfile : Profile
    {
        public ProcedureDetailsProfile()
        {
            AddProcedureDetailsMapping();
            UpdateProcedureDetailsMapping();
            GetProcedureDetailsPaginationQuery();
            GetProcedureDetailsByIdQuery();
        }
    }
}
