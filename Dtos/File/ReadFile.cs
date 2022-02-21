using System;

namespace UploadFilePDF.Dtos.File
{
    public class ReadFile
    {
        public long Id { get; set; }
        public string ContentType { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public System.Nullable<DateTime> CreatedAt { get; set; }
        public System.Nullable<DateTime> UpdatedAt { get; set; }
    }
}
