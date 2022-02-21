using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UploadFilePDF.Entities
{
    [Table(name: "FilesPdf")]
    public class AppFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public long Id { get; set; }

        [Column(name: "content_type")]
        public string ContentType { get; set; }

        [Column(name: "length")]
        public long Length { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "file_name")]
        public string FileName { get; set; }

        [Column(name: "created_at")]
        public System.Nullable<DateTime> CreatedAt { get; set; }

        [Column(name: "updated_at")]
        public System.Nullable<DateTime> UpdatedAt { get; set; }
    }
}
