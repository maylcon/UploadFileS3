using Microsoft.EntityFrameworkCore;
using UploadFilePDF.Entities;

namespace UploadFilePDF.DbContexts
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        { }

        public virtual DbSet<AppFile> Files { get; set; }
    }
}
