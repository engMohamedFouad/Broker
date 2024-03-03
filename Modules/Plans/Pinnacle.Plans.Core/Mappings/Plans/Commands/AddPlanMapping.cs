using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Plans.Commands.Models;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Mappings.Plans
{
    public partial class PlanProfile
    {
        public void AddPlanMapping()
        {
            CreateMap<AddPlansCommand, YearlyPlan>()
               .ForMember(opt => opt.DangerStatus, des => des.MapFrom(src => (int)src.DangerStatus))
               .ForMember(opt => opt.ProcedureDanger, des => des.MapFrom(src => (int)src.ProcedureDanger))
               .ForMember(opt => opt.YearlyPlanManagementsNavigations, des => des.MapFrom(src => src.Managements))
               .ForMember(opt => opt.YearlyPlanUsersNavigations, des => des.MapFrom(src => src.Users))
               .ForMember(opt => opt.YearlyPlanReviewsNavigations, des => des.MapFrom(src => src.Reviews))
               .ForMember(opt => opt.YearlyPlanReviewTopicsNavigations, des => des.MapFrom(src => src.ReviewTopics))
               .ForMember(opt => opt.YearlyPlanFirstlyDatasNavigations, des => des.MapFrom(src => src.firstlyInformations))
               .ForMember(opt => opt.YearlyPlanBranchNavigations, des => des.MapFrom(src => src.Branches));

            CreateMap<AddManagementDTO, YearlyPlanManagement>()
                .ForMember(opt => opt.MId, des => des.MapFrom(src => src.Id));

            CreateMap<AddUserDTO, YearlyPlanUsers>()
                .ForMember(opt => opt.UId, des => des.MapFrom(src => src.Id))
                .ForMember(opt => opt.Type, des => des.MapFrom(src => 0));

            CreateMap<AddReviewTopicsDTO, YearlyPlanReviewTopic>()
               .ForMember(opt => opt.RTId, des => des.MapFrom(src => src.Id));

            CreateMap<AddReviewDTO, YearlyPlanReview>()
              .ForMember(opt => opt.RId, des => des.MapFrom(src => src.Id));

            CreateMap<AddFirstlyDataDTO, YearlyPlanFirstlyData>()
             .ForMember(opt => opt.FDId, des => des.MapFrom(src => src.Id));

            CreateMap<AddBranchDTO, YearlyPlanBranch>()
            .ForMember(opt => opt.BId, des => des.MapFrom(src => src.Id));
        }
    }
}
