using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.AttachmentServices
{
    public class AttachmentService : IAttachmentService
    {
        List<string> AllowedExtensions =  [ ".jpg", ".png", ".jpeg" ];
        const int maxSize = 2 * 1024 * 1024;
        public string? Upload(IFormFile file, string FolderName)
        {
            //Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(extension)) return null;

            //Check Size
            if (file.Length > maxSize || file.Length == 0) return null;
            //Get Located Folder Path
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            //Make Attachment Name Unique
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            //Get Full File Path
            var FilePath = Path.Combine(FolderPath, fileName); //File Locationf
            //Create File Stream
            using FileStream fs  = new FileStream(FilePath, FileMode.Create) ;
            //Use Stream Copy
            file.CopyTo(fs);
            //Return File Path To Store In DB
            return fileName;
        }
        public bool Delete(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            else
            {
                File.Delete(filePath);
                return true;
            }
        }

    }
}
