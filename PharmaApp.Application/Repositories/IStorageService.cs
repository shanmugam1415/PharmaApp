using Microsoft.AspNetCore.Http;

namespace PharmaApp.Application.Repositorie
{
    public interface IStorageService
    {
        public  Task<string> UploadFileAsync(IFormFile file, string folderName);
        public  Task<List<string>> ListFilesAsync(string folderPath);
        public Task DeleteFileAsync(string fileKey);
        public  Task<string> GetTemporaryUrl(string path);
        public Task DeleteProjectFolderFromS3(string projectName);
        public Task<string> UploadVideosFileAsync(IFormFile file, string folderName);
        Task<MemoryStream> GetLocalFileAsync(string filePath);
        Task<MemoryStream> GetS3FileAsync(string bucketName, string objectKey);

    }
}
