
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PersonalProject.API.Application.Validations;
using PersonalProject.API.CQRS.Services;
using PersonalProject.API.CQRS.User.Commands.createPost;
using PersonalProject.API.CQRS.User.Commands.RegisterUser;
using PersonalProject.API.Helper;
using PersonalProject.Utils.ClaimManager;
using System.Text;

namespace PersonalProject.API.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureABCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IClaimsManager, ClaimsManager>();
           // services.AddScoped<IValidator<LoginUserQuery>, LoginUserQueryValidator>();
           // services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();
            
            services.AddHttpContextAccessor();

            services.AddAuthentication(options =>
            {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>  //default authentication scheme
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["AppAuth:Issuer"],
                    ValidAudience = configuration["AppAuth:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppAuth:Key"])),
                    ClockSkew = TimeSpan.Zero,
                   LifetimeValidator = TokenLifetimeValidator.Validate
                };
            });
            // configure DI for application services

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1", Description = "Api for the AppService Application that will be consumed for web and mobile apps." });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                x.CustomSchemaIds(type => type.ToString());
            });

            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            return services;

        }
    }
}
