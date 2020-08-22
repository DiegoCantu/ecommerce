using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Set Global Variables (Connection String Database, JWT, etc):
            GlobalVariables.Setter(Configuration);
            //Custom Methods:
            ServiceExtensions.AddController(services);
            ServiceExtensions.AddDbContext(services);
            ServiceExtensions.AddJWT(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // { Custom Method:
            ConfigureExtensions.GlobalExceptions(app);
            // }

            app.UseRouting();

            // { JWT:
            app.UseAuthentication();
            // }

            // { CORS:
            app.UseCors("EnableCORS");
            // }

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
