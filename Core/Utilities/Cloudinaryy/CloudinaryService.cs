using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Cloudinaryy
{
    public class CloudinaryService
    {
        Cloudinary cloudinary;
        public CloudinaryService()
        {

            Account account = new Account(

            "seda-yegin",
            "996287275398472",
            "5xcS3mtpuFPu5U3YV39fRp_jCXE");

            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public ImageUploadResult Upload(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName,file.OpenReadStream()),
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            return uploadResult;
        }

    }
}
