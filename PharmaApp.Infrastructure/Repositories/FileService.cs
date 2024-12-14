using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaApp.Application.Repositories;

namespace PharmaApp.Infrastructure.Repositories
{
    public class FileService : IFileService
    {
        private readonly string _uploadPath;

        public FileService(IConfiguration configuration)
        {
            _uploadPath = configuration["FileUploadPath"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var fullPath = Path.Combine(_uploadPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fullPath;
        }
    }

}
