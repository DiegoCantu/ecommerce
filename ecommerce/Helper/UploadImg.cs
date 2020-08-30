using System;
using System.IO;

namespace ecommerce.Helper
{
    public class UploadImg
    {
        public static void Save(string sku,string base64, string folderName)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, sku + ".png");
            var bytes = Convert.FromBase64String(base64);
            using (var imageFile = new FileStream(fullPath, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }
    }
}
