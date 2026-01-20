using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NtierArchitecture.Business.Services.Abstract;

namespace NtierArchitecture.Business.Services.Concrete
{
    public class FileManager : IFileService
    {
        private readonly string _webRootPath;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png" };
        private const long _maxFileSize = 2 * 1024 * 1024;
        public FileManager(IWebHostEnvironment env)
        {
            _webRootPath = env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }
        public void Delete(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) 
                return;

            var fullPath = Path.Combine(_webRootPath, filePath.TrimStart('/'));

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }

        public async Task<string> UploadAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Fayl seçilməyib.");

            if (file.Length > _maxFileSize)
                throw new Exception("Maksimum ölçü 2MB ola bilər.");

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (!_allowedExtensions.Contains(extension))
                throw new Exception("Yanlış fayl formatı.");

            var fileName = $"{Guid.NewGuid()}{extension}";

            var uploadFolder = Path.Combine(_webRootPath, "uploads", folderName);

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var fullPath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{folderName}/{fileName}";
        }
    }
}
