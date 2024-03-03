using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Plans
{
    public partial class PlanProfile : Profile
    {
        public PlanProfile()
        {
            GetPlansPaginationMapping();
            GetPlanByIdMapping();
            AddPlanMapping();
            UpdatePlansMapping();
        }
    }
}
