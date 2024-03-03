using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Procedures
{
    public partial class ProcedureProfile
    {
        public void GetProcedurePaginationMapping()
        {
            CreateMap<Procedure, GetProcedurePaginationResult>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
