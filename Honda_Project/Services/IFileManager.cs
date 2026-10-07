using Honda_Project.Enums;

namespace Honda_Project.Services
{
    public interface IFileManager
    {
        Task<string> SaveFileAsync(IFormFile file,AssetPath type);
        void DeleteFile(string fileUrl);
    }
}
