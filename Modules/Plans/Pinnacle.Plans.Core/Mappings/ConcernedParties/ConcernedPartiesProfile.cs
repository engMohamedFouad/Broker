using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.ConcernedParties
{
    public partial class ConcernedPartiesProfile : Profile
    {
        public ConcernedPartiesProfile()
        {
            GetConcernedPartiesPaginationMapping();
            GetConcernedPartiesByIdMapping();
            AddConcernedPartiesMapping();
            UpdateConcernedPartiesMapping();
        }
    }
}
