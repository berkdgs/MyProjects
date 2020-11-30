using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PASTR.Intranet.Utility
{
    public class ImageUploader
    {
        public static String UploadImage(String serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();
                String[] filePart = file.FileName.Split('.');
                String fileExtention = filePart[filePart.Length - 1];
                String fileName = uniqueName + "." + fileExtention;
                if (fileExtention.ToLower() == "jpg" || fileExtention.ToLower() == "jpeg" || fileExtention.ToLower() == "png" || fileExtention.ToLower() == "gif" || fileExtention.ToLower() == "bmp")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                        return "1";
                    else
                    {
                        String filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                    return "2";
            }
            return "0";
        }
    }
}