using Microsoft.Extensions.DependencyInjection;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Infrastructure.Repositories;

namespace Pinnacle.Plans.Infrastructure
{
    public static class ModuleInfrastructureExtentions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IConcernedPartyRepository, ConcernedPartyRepository>();
            services.AddTransient<IManagementRepository, ManagementRepository>();
            services.AddTransient<IPhoneNumbersRepository, PhoneNumbersRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IFirstlyInformationRepository, FirstlyInformationRepository>();
            services.AddTransient<IReviewTopicRepository, ReviewTopicRepository>();
            services.AddTransient<IPlanRepository, PlanRepository>();
            services.AddTransient<IYearlyPlanManagementRepository, YearlyPlanManagementRepository>();
            services.AddTransient<IYearlyPlanUsersRepository, YearlyPlanUsersRepository>();
            services.AddTransient<IYearlyPlanReviewTopicRepository, YearlyPlanReviewTopicRepository>();
            services.AddTransient<IYearlyPlanReviewRepository, YearlyPlanReviewRepository>();
            services.AddTransient<IYearlyPlanFirstlyDataRepository, YearlyPlanFirstlyDataRepository>();
            services.AddTransient<IIndicatorsRepository, IndicatorsRepository>();
            //services.AddTransient<IIndicatorDetailsRepository, IndicatorDetailsRepository>();
            services.AddTransient<IFilesRepository, FilesRepository>();
            services.AddTransient<IIndicatorsCategoryRepository, IndicatorsCategoryRepository>();
            services.AddTransient<ISystemLogRepository, SystemLogRepository>();
            services.AddTransient<IReviewPointsRepository, ReviewPointsRepository>();
            services.AddTransient<IPointCommentsRepository, PointCommentsRepository>();
            services.AddTransient<IPointsFilesRepository, PointsFilesRepository>();
            services.AddTransient<IUserPointRepository, UserPointRepository>();
            services.AddTransient<IProcedureRepository, ProcedureRepository>();
            services.AddTransient<IProcedureDetailsRepository, ProcedureDetailsRepository>();
            services.AddTransient<IProcedureDetailsFileRepository, ProcedureDetailsFileRepository>();
            services.AddTransient<IIndicatorProcedureRepository, IndicatorProcedureRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IYearlyPlanBranchRepository, YearlyPlanBranchRepository>();
            //views

            //Procedure

            //functions

            return services;
        }
    }
}
