using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ShopyEcomerce
{
 public   class CloudinaryUploader
    {
      public static string Upload(HttpPostedFileBase photo)
      {

        var myAccount = new Account { ApiKey = ConfigurationManager.AppSettings["CloudinaryApiKey"], ApiSecret = ConfigurationManager.AppSettings["CloudinarySecretKey"], Cloud = ConfigurationManager.AppSettings["CloudName"] };
        Cloudinary _cloudinary = new Cloudinary(myAccount);
        var uploadParams = new ImageUploadParams
        {
          File = new FileDescription(photo.FileName, photo
            .InputStream),
          //transformation code here
          Transformation = new Transformation().Width(200).Height(200).Crop("thumb").Gravity("face")
        };

        var uploadResult = _cloudinary.Upload(uploadParams);
       return uploadResult.SecureUri.OriginalString;
    }
    }
}
