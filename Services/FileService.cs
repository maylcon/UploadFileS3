using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using UploadFilePDF.Dtos.File;
using UploadFilePDF.Entities;
using UploadFilePDF.Repositories;
using Minio;

namespace UploadFilePDF.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;
        private readonly IMapper _mapper;

        public FileService(IFileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ReadFile SaveFileDisc(IFormFile createRequest, string rootPath)
        {
            Directory.CreateDirectory(Path.Combine(rootPath, "archivos"));
            var fileName = Path.Combine(rootPath, "archivos", createRequest.FileName);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                createRequest.CopyTo(fileStream);
            }

            return SaveInfoFileDb(createRequest, fileName);

        }

        public ReadFile SaveFileS3(IFormFile createRequest, string rootPath)
        {

            using (var memoryStream = new MemoryStream())
            {
                var minioClient = new MinioClient("s3-us-east-1.amazonaws.com", "", "").WithSSL();

                createRequest.CopyToAsync(memoryStream);
                byte[] bs = memoryStream.ToArray();
                var ms = new MemoryStream(bs);
                minioClient.PutObjectAsync("awsbucketalexfomo", createRequest.FileName,
                    ms, ms.Length, "application/octet-stream", null, null);
            }


            return SaveInfoFileDb(createRequest, "awsbucketalexfomo");
        }

        public ReadFile SaveInfoFileDb(IFormFile createRequest, string rootPath)
        {

            AppFile entity = _mapper.Map<IFormFile, AppFile>(createRequest);
            entity = _repository.SaveFile(entity);
            ReadFile dto = _mapper.Map<AppFile, ReadFile>(entity);
            dto.Path = rootPath;
            return dto;
        }
    }
}
