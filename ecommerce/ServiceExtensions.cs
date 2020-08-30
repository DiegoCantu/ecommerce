using ecommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using ecommerce.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System;
using AutoMapper;
using ecommerce.Application;

namespace ecommerce
{
    public static class ServiceExtensions
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ContextDb>(options =>
            {
                options.UseNpgsql(GlobalVariables.ConnectionString);
            });
        }

        public static void AddController(this IServiceCollection services)
        {
            // Until AddControllers() is the default template
            // AddFluentValidation is the way to register the nugget for input validations on determinate class.
            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<User>());
        }

        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });
        }

        public static void AddJWT(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = GlobalVariables.JWTParameters.Issuer,
                    ValidAudience = GlobalVariables.JWTParameters.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(GlobalVariables.JWTParameters.SigningKey))
                };
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Ecommerce {groupName}",
                    Version = groupName,
                    Description = "Ecommerce API",
                    Contact = new OpenApiContact
                    {
                        Name = "rEact Commerce",
                        Email = string.Empty,
                        Url = new Uri("https://react-commerce-baa6f.web.app/"),
                    }
                });
            });
        }

        public static void AddMapper(this IServiceCollection services)
        { 
            services.AddAutoMapper(typeof(AddressActions));
        }

    }
}
