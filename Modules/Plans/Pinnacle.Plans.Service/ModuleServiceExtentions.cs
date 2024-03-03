using Microsoft.Extensions.DependencyInjection;
using Pinnacle.Plans.Service.Implementations;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service
{
    public static class ModuleServiceExtentions
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IConcernedPartyService, ConcernedPartyService>();
            services.AddTransient<IManagementService, ManagementService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IFirstlyInformationService, FirstlyInformationService>();
            services.AddTransient<IReviewTopicService, ReviewTopicService>();
            services.AddTransient<IPlanService, PlanService>();
            services.AddTransient<IIndicatorService, IndicatorService>();
            // services.AddTransient<IIndicatorDetailsService, IndicatorDetailsService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ICurrentUrlService, CurrentUrlService>();
            services.AddTransient<IIndicatorsCategoryService, IndicatorsCategoryService>();
            services.AddTransient<ISystemLogService, SystemLogService>();
            services.AddTransient<IReviewPointsService, ReviewPointsService>();
            services.AddTransient<IPointsCommentsService, PointsCommentsService>();
            services.AddTransient<IUserPointService, UserPointService>();
            services.AddTransient<IProcedureService, ProcedureService>();
            services.AddTransient<IProcedureDetailsService, ProcedureDetailsService>();
            services.AddTransient<IBranchService, BranchService>();
            return services;
        }
    }
}
