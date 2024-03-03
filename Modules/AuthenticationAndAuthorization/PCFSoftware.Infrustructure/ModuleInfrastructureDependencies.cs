using Microsoft.Extensions.DependencyInjection;
using Broker.AuthenticationAndAuthorization.Infrustructure.Abstracts;
using Broker.AuthenticationAndAuthorization.Infrustructure.Repositories;

namespace Broker.AuthenticationAndAuthorization.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IUserPermissionsRepository, UserPermissionsRepository>();
            services.AddTransient<IRolePermissionsRepository, RolePermissionsRepository>();

            //views

            //Procedure

            //functions

            return services;
        }
    }
}