using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Broker.Infrastructure.Builders.AuthServices.Implementations;
using Broker.Infrastructure.Builders.AuthServices.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;

namespace Broker.Infrastructure.Builders
{
    public static class ModuleExtentions
    {
        public static IServiceCollection AddSharedModulesExtentions(this IServiceCollection services)
        {
            services.AddTransient<ICurrentUserService, CurrentUserService>();

            #region Localization
            services.AddControllersWithViews();
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                   new CultureInfo("en-US"),
                   new CultureInfo("de-DE"),
                   new CultureInfo("fr-FR"),
                   new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.DefaultModelsExpandDepth(-1);
                options.SwaggerEndpoint("/swagger/AuthenticationAndAuthorization/swagger.json", "AuthenticationAndAuthorization");
                options.SwaggerEndpoint("/swagger/Plans/swagger.json", "Plans");
                options.RoutePrefix = "swagger";
                options.DisplayRequestDuration();
                options.DocExpansion(DocExpansion.None);
            });
            //allow Core
            app.UseCors("_cors");
            return app;
        }
    }
}