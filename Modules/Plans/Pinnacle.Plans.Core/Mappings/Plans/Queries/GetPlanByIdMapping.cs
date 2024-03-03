using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Plans.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Plans
{
    public partial class PlanProfile
    {
        public void GetPlanByIdMapping()
        {
            CreateMap<YearlyPlan, GetPlanByIdResult>()
               .ForMember(opt => opt.PartyName, des => des.MapFrom(src => src.Localize(src.ConcernedPartyNavigation.NameAr, src.ConcernedPartyNavigation.NameEn)))
               .ForMember(opt => opt.Managements, des => des.MapFrom(src => src.YearlyPlanManagementsNavigations))
               .ForMember(opt => opt.Users, des => des.MapFrom(src => src.YearlyPlanUsersNavigations))
               .ForMember(opt => opt.Reviews, des => des.MapFrom(src => src.YearlyPlanReviewsNavigations))
               .ForMember(opt => opt.ReviewTopics, des => des.MapFrom(src => src.YearlyPlanReviewTopicsNavigations))
               .ForMember(opt => opt.firstlyInformations, des => des.MapFrom(src => src.YearlyPlanFirstlyDatasNavigations))
               .ForMember(opt => opt.Branches, des => des.MapFrom(src => src.YearlyPlanBranchNavigations));
        }
    }
}
