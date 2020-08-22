using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace ecommerce.Helper
{
    public class ELog
    {
        public static void Save(object obj, Exception ex)
        {
            try
            {
                var folderName = Path.Combine("Log", "Errors");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                string date = DateTime.Now.ToString("yyyyMMdd");
                string time = DateTime.Now.ToString("HHmmss");
                var fullPath = Path.Combine(pathToSave, date + "-" + time + ".txt");

                StreamWriter sw = new StreamWriter(fullPath, true);
                StackTrace stacktrace = new StackTrace();
                var message = JsonConvert.SerializeObject(obj);
                sw.WriteLine(message);
                sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name + " - " + ex.Message);
                sw.WriteLine("");

                sw.Flush();
                sw.Close();
            }
            catch (Exception) { }
        }
    }
}
