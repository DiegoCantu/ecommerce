using ecommerce.Helper;
using ecommerce.Models;
using Npgsql;
using System;

namespace ecommerce.Application
{
    public class LogActions
    {
        public static async void SaveError(Log log)
        {
            await using var conn = new NpgsqlConnection(GlobalVariables.ConnectionString);
            await using var cmd = conn.CreateCommand();
            await cmd.Connection.OpenAsync();
            DateTime now = DateTime.Now;
            string date = now.ToString("yyyy-MM-dd");
            string sp = "CALL save_log(" +
                "email => '"             + log.Email + "' ," +
                "messageexception => '" + log.MessageException.Replace("'", "") + "' ," +
                "innerexception => '"   + log.InnerException.Replace("'","") + "' ," +
                "stacktrace => '"       + log.StackTrace.Replace("'", "") + "'," +
                "helplink => '"         + log.HelpLink.Replace("'", "") + "' ," +
                "hresult => '"          + log.HResult.Replace("'", "") + "' ," +
                "sourceexception => '"  + log.SourceException.Replace("'", "") + "'," +
                "targetsite => '"       + log.TargetSite.Replace("'", "") + "'," +
                "createdate => '"       + date + "');";
            cmd.CommandText = sp;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ELog.Save(log, ex, sp);
            } 
            finally
            {
                await cmd.Connection.CloseAsync();
            }
        }
    }
}
