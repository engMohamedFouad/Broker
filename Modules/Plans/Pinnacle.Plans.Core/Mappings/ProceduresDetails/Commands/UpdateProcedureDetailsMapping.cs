using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.ProceduresDetails
{
    public partial class ProcedureDetailsProfile
    {
        public void UpdateProcedureDetailsMapping()
        {
            CreateMap<UpdateProcedureDetailsCommand, ProcedureDetails>();
        }
    }
}
