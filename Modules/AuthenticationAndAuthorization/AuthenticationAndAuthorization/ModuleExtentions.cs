using Microsoft.Extensions.DependencyInjection;
using Broker.AuthenticationAndAuthorization.Core;
using Broker.AuthenticationAndAuthorization.Infrustructure;
using Broker.AuthenticationAndAuthorization.Service;

namespace AuthenticationAndAuthorization
{
    public static class ModuleExtentions
    {
        public static IServiceCollection AddAuthenticationAndAuthorizationDependencies(this IServiceCollection services)
        {

            services.AddInfrastructureDependencies()
                    .AddServiceDependencies()
                    .AddCoreDependencies();
            return services;
        }
    }
}