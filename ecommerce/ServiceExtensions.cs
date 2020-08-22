using ecommerce.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using ecommerce.Models;

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
    }
}
