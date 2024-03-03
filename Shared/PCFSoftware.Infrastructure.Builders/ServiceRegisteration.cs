using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Broker.AuthenticationAndAuthorization.Data.Helpers;
using Broker.Data.Entities.Identity;
using Broker.Infrustructure.Context;
using Broker.Infrustructure.InfrastructureBases;
using System.Text;

namespace Broker.Infrastructure.Builders
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            #region Identity

            services.AddIdentity<User, Role>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<ApplicationDBContext>().AddDefaultTokenProviders();

            //JWT Authentication
            var jwtSettings = new JwtSettings();
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(jwtSettings);
            services.AddSingleton(emailSettings);

            #endregion


            #region Authentication

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtSettings.ValidateIssuer,
                   ValidIssuers = new[] { jwtSettings.Issuer },
                   ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                   ValidAudience = jwtSettings.Audience,
                   ValidateAudience = jwtSettings.ValidateAudience,
                   ValidateLifetime = jwtSettings.ValidateLifeTime,
               };
           });

            #endregion


            #region Swagger Document

            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("AuthenticationAndAuthorization", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AuthenticationAndAuthorization",
                    Description = "Authentication And Authorization",
                });
                c.SwaggerDoc("Plans", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Plans",
                    Description = "Plans",
                });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                {
                  new OpenApiSecurityScheme
                  {
                   Reference = new OpenApiReference
                   {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                   }
                  },
                  Array.Empty<string>()
                }
                });
            });

            #endregion



            #region AllowCORS
            var CORS = "_cors";
            services.AddCors(options =>
             {
                 options.AddPolicy(name: CORS,
                                   policy =>
                                   {
                                       policy.AllowAnyHeader();
                                       policy.AllowAnyMethod();
                                       policy.AllowAnyOrigin();
                                   });
             });

            #endregion




            #region Permissions in System


            services.AddAuthorization(option =>
            {
                option.AddPolicy("Create Plan", policy =>
                {
                    policy.RequireClaim("Create Plan", "True");
                });
                option.AddPolicy("Update Plan", policy =>
                {
                    policy.RequireClaim("Update Plan", "True");
                });
                option.AddPolicy("Delete Plan", policy =>
                {
                    policy.RequireClaim("Delete Plan", "True");
                });



                option.AddPolicy("Create ConcernedParty", policy =>
                {
                    policy.RequireClaim("Create ConcernedParty", "True");
                });
                option.AddPolicy("Update ConcernedParty", policy =>
                {
                    policy.RequireClaim("Update ConcernedParty", "True");
                });
                option.AddPolicy("Delete ConcernedParty", policy =>
                {
                    policy.RequireClaim("Delete ConcernedParty", "True");
                });


            });


            #endregion



            return services;
        }
    }
}
