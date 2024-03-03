using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Procedures
{
    public partial class ProcedureProfile
    {
        public void GetProcedureByIdMapping()
        {
            CreateMap<Procedure, GetProcedureByIdResult>();
        }
    }
}
