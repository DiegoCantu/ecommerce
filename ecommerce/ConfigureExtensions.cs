using ecommerce.Application;
using ecommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ecommerce
{
    public static class ConfigureExtensions
    {
        public static void GlobalExceptions(this IApplicationBuilder app)
        {
            //Global Try-Catch
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;
                        Log log = new Log
                        {
                            IdUser = GlobalVariables.IdUser,
                            HelpLink = ex.HelpLink ?? string.Empty,
                            HResult = ex.HResult.ToString(),
                            MessageException = ex.Message ?? string.Empty,
                            InnerException = ex.InnerException != null ? ex.InnerException.Message + ":" + ((Npgsql.PostgresException)ex.InnerException).Detail : string.Empty,
                            SourceException = ex.Source,
                            StackTrace = ex.StackTrace,
                            TargetSite = ex.TargetSite != null ? ex.TargetSite.Name : string.Empty
                        };
                        LogActions.SaveError(log);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(log, Formatting.Indented));
                    }
                });
            });
        }
    }
}
