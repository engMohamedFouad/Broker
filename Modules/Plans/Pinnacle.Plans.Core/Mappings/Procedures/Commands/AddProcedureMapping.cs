using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Procedures.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.Procedures
{
    public partial class ProcedureProfile
    {
        public void AddProcedureMapping()
        {
            CreateMap<AddProcedureCommand, Procedure>();
        }
    }
}
