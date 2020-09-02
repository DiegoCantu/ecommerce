using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

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
            ServiceExtensions.AddCORS(services);
            ServiceExtensions.AddJWT(services);
            ServiceExtensions.AddSwagger(services);
            ServiceExtensions.AddMapper(services);
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

            // { Swagger:
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "rEact Commerce API V1");
            });
            // }

            // { Static Files Server
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "ImgProducts")),
                RequestPath = "/Images"
            });
            // }

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
