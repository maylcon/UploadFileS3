using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using UploadFilePDF.Dtos.File;

namespace UploadFilePDF.Services
{
    public interface IFileService
    {
        public ReadFile SaveFileDisc(IFormFile createRequest, string rootPath);
        public ReadFile SaveFileS3(IFormFile createRequest, string rootPath);
    }
}
