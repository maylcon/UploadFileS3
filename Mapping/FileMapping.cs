using AutoMapper;
using Microsoft.AspNetCore.Http;
using UploadFilePDF.Dtos.File;
using UploadFilePDF.Entities;

namespace UploadFilePDF.Mapping
{
    public class FileMapping : Profile
    {
        public FileMapping()
        {
            CreateMap<AppFile, ReadFile>();
            CreateMap<IFormFile, AppFile>()
            .ForMember(c => c.ContentType, opt => opt.MapFrom(f => f.ContentType))
            .ForMember(c => c.Name, opt => opt.MapFrom(f => f.FileName))
            .ForMember(c => c.Length, opt => opt.MapFrom(f => f.Length));
        }
    }
}
