using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Plans.Queries.Results;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Mappings.Plans
{
    public partial class PlanProfile
    {
        public void GetPlansPaginationMapping()
        {
            CreateMap<YearlyPlan, GetPlansPaginationResult>()
                .ForMember(opt => opt.PartyName, des => des.MapFrom(src => src.Localize(src.ConcernedPartyNavigation.NameAr, src.ConcernedPartyNavigation.NameEn)))
                .ForMember(opt => opt.Managements, des => des.MapFrom(src => src.YearlyPlanManagementsNavigations))
                .ForMember(opt => opt.Reviews, des => des.MapFrom(src => src.YearlyPlanReviewsNavigations))
                .ForMember(opt => opt.ReviewTopics, des => des.MapFrom(src => src.YearlyPlanReviewTopicsNavigations))
                .ForMember(opt => opt.firstlyInformations, des => des.MapFrom(src => src.YearlyPlanFirstlyDatasNavigations))
                .ForMember(opt => opt.Branches, des => des.MapFrom(src => src.YearlyPlanBranchNavigations));

            CreateMap<YearlyPlanManagement, ManagementDTO>()
                .ForMember(opt => opt.Id, des => des.MapFrom(src => src.MId))
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.ManagementNavigation.NameAr, src.ManagementNavigation.NameEn)));

            CreateMap<YearlyPlanUsers, UserDTO>()
                .ForMember(opt => opt.Id, des => des.MapFrom(src => src.UId))
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.UserNavigation!.UserName));

            CreateMap<YearlyPlanReviewTopic, ReviewTopicsDTO>()
               .ForMember(opt => opt.Id, des => des.MapFrom(src => src.RTId))
               .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.ReviewTopicNavigation.DescriptionAr, src.ReviewTopicNavigation.DescriptionEn)));

            CreateMap<YearlyPlanReview, ReviewDTO>()
              .ForMember(opt => opt.Id, des => des.MapFrom(src => src.RId))
              .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.ReviewNavigation.TypeAr, src.ReviewNavigation.TypeEn)));

            CreateMap<YearlyPlanFirstlyData, FirstlyDataDTO>()
             .ForMember(opt => opt.Id, des => des.MapFrom(src => src.FDId))
             .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.FirstlyDataNavigation.DescriptionAr, src.FirstlyDataNavigation.DescriptionEn)));

            CreateMap<YearlyPlanUsers, UserManagersDTO>()
           .ForMember(opt => opt.Id, des => des.MapFrom(src => src.UId))
           .ForMember(opt => opt.Name, des => des.MapFrom(src => src.UserNavigation.FullName));

            CreateMap<YearlyPlanBranch, BranchesDTO>()
          .ForMember(opt => opt.Id, des => des.MapFrom(src => src.BId))
          .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.BranchNavigation.NameAr, src.BranchNavigation.NameEn)));
        }

    }
}