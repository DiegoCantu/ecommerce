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
                        string postgreSQLException = "Empty";
                        if (((Npgsql.PostgresException)ex.InnerException) != null)
                        {
                            try { postgreSQLException = ((Npgsql.PostgresException)ex.InnerException).Detail; } catch (System.Exception) { }
                        }
                        Log log = new Log
                        {
                            Email = GlobalVariables.Email ?? "Anónimo",
                            HelpLink = ex.HelpLink ?? "Empty",
                            HResult = ex.HResult.ToString(),
                            MessageException = ex.Message ?? "Empty",
                            InnerException = ex.InnerException != null ? ex.InnerException.Message + ":" + postgreSQLException : "Empty",
                            SourceException = ex.Source,
                            StackTrace = ex.StackTrace,
                            TargetSite = ex.TargetSite != null ? ex.TargetSite.Name : "Empty"
                        };
                        LogActions.SaveError(log);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(log, Formatting.Indented));
                    }
                });
            });
        }
    }
}
