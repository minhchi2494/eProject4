using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using WebAPI.Models;

namespace WebAPI.Services.Cloudinary
{
    public class CloudinaryService
    {
        private readonly IProductServices _services;

        public const string CLOUD_NAME = "da85i8t2o";
        public const string API_KEY = "782372915787355";
        public const string API_SECRET = "6peu85e37dcz83v7zrm8IsX3d5k";

        public CloudinaryService(IProductServices services)
        {
            _services = services;
        }

        public void upload(string filepath, Product product)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            var service = new CloudinaryDotNet.Cloudinary(account);
            //store to cloud
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filepath)
            };
            var uploadResult = service.Upload(uploadParams);
            product.Images = uploadResult.Url.ToString();
            _services.updateProduct(product);
        }
    }
}
