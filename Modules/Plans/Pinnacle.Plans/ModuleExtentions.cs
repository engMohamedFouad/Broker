using Microsoft.Extensions.DependencyInjection;
using Pinnacle.Plans.Core;
using Pinnacle.Plans.Infrastructure;
using Pinnacle.Plans.Service;


namespace Pinnacle.Plans
{
    public static class ModuleExtentions
    {
        public static IServiceCollection AddPlansDependencies(this IServiceCollection services)
        {

            services.AddInfrastructureDependencies()
                    .AddServiceDependencies()
                    .AddCoreDependencies();
            return services;
        }
    }
}
