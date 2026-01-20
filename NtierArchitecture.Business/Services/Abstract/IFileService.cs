using Microsoft.AspNetCore.Http;

namespace NtierArchitecture.Business.Services.Abstract
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
        void Delete(string filePath);
    }
}
