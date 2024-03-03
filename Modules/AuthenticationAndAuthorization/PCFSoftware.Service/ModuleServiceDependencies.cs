using Microsoft.Extensions.DependencyInjection;
using Broker.AuthenticationAndAuthorization.Service.Abstracts;
using Broker.AuthenticationAndAuthorization.Service.Implementations;
using Broker.Infrastructure.Builders.AuthServices.Implementations;
using Broker.Infrastructure.Builders.AuthServices.Interfaces;

namespace Broker.AuthenticationAndAuthorization.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailsService, EmailsService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IFileService, FileService>();
            return services;
        }
    }
}