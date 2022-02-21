using UploadFilePDF.Entities;

namespace UploadFilePDF.Repositories
{
    public interface IFileRepository
    {
        AppFile SaveFile(AppFile entity);
    }
}
