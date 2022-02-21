using System;
using UploadFilePDF.DbContexts;
using UploadFilePDF.Entities;

namespace UploadFilePDF.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDbContext _context;

        public FileRepository(FileDbContext context)
        {
            _context = context;
        }

        public AppFile SaveFile(AppFile entity)
        {

            var result = new AppFile();
            try
            {
                var response = _context.Add(entity);
                _context.SaveChanges();
                result = response.Entity;
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }

            return result;
        }
    }
}
