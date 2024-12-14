using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PharmaApp.Application.Repositorie;

namespace PharmaApp.Infrastructure.Repositories
{

    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _amazonS3clinet;
        private readonly string? _bucketName;
        

        public StorageService(IAmazonS3 amazonS3,IConfiguration configuration)
        {
           
            _bucketName = configuration["Aws:BucketName"];

            _amazonS3clinet = new AmazonS3Client( new AmazonS3Config
            {
                RegionEndpoint = RegionEndpoint.USEast1,
                UseAccelerateEndpoint = true 
            });
        }


        
        public async Task<string> UploadFileAsync(IFormFile file,string folderName)
        {
    
            using (var stream=file.OpenReadStream())
            {
                var uploadObj = new PutObjectRequest
                {
                    BucketName = _bucketName,
                    Key=folderName,
                    InputStream=stream,
               
                    ContentType=file.ContentType


                };
                await _amazonS3clinet.PutObjectAsync(uploadObj);
               

            }

            return $"https://{_bucketName}.s3.amazonaws.com/{folderName}";
        }
      
        public async Task<string> UploadVideosFileAsync(IFormFile file, string folderName)
        {
         
            var initiateRequest = new InitiateMultipartUploadRequest
            {
                BucketName = _bucketName,
                Key = folderName,
                ContentType = file.ContentType
            };

            var initiateResponse = await _amazonS3clinet.InitiateMultipartUploadAsync(initiateRequest);
            var uploadId = initiateResponse.UploadId;

           
            var partSize = 5 * 1024 * 1024; // 5 MB
            var fileStream = file.OpenReadStream();
            var partETags = new List<PartETag>();

            try
            {
               
                int partNumber = 1;
                var buffer = new byte[partSize];
                int bytesRead;

                while ((bytesRead = await fileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    
                    var partStream = new MemoryStream(buffer, 0, bytesRead);

                    var uploadRequest = new UploadPartRequest
                    {
                        BucketName = _bucketName,
                        Key = folderName,
                        UploadId = uploadId,
                        PartNumber = partNumber,
                        InputStream = partStream,
                        PartSize = bytesRead 
                    };

                    var uploadResponse = await _amazonS3clinet.UploadPartAsync(uploadRequest);
                    partETags.Add(new PartETag(partNumber, uploadResponse.ETag));

                    partNumber++;
                }

           
                var completeRequest = new CompleteMultipartUploadRequest
                {
                    BucketName = _bucketName,
                    Key = folderName,
                    UploadId = uploadId,
                    PartETags = partETags
                };

                var completeResponse = await _amazonS3clinet.CompleteMultipartUploadAsync(completeRequest);
          
                return completeResponse.Location; 
            }
            catch (Exception ex)
            {
               
                await _amazonS3clinet.AbortMultipartUploadAsync(new AbortMultipartUploadRequest
                {
                    BucketName = _bucketName,
                    Key = $"{folderName}/{file.FileName}",
                    UploadId = uploadId
                });
                throw new Exception("Upload failed, aborted multipart upload", ex);
            }
            finally
            {
                fileStream.Dispose();
            }
        }

        public async Task<List<string>> ListFilesAsync(string folderPath)
        {
            var request = new ListObjectsV2Request
            {
                BucketName = _bucketName,
                Prefix = folderPath // List files under this "folder" (prefix)
            };

            var response = await _amazonS3clinet.ListObjectsV2Async(request);

            // Return list of file keys (empty list if no files are found)
            return response.S3Objects.Select(o => o.Key).ToList();
        }
        public async Task DeleteFileAsync(string fileKey)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileKey
            };

            await _amazonS3clinet.DeleteObjectAsync(deleteObjectRequest);
        }
        public async Task<string> GetTemporaryUrl( string path)
        {
            
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _bucketName,
                Key =path, 
                Expires = DateTime.Now.AddMinutes(60) 
            };

            var presignedUrl = _amazonS3clinet.GetPreSignedURL(request);
            return presignedUrl;
        }
        public async Task DeleteProjectFolderFromS3(string projectName)
        {
          
            var request = new ListObjectsV2Request
            {
                BucketName = _bucketName,
                Prefix = projectName + "/" 
            };

            var response = await _amazonS3clinet.ListObjectsV2Async(request);
            if (response.S3Objects.Count > 0)
            {
                
                var deleteRequest = new DeleteObjectsRequest
                {
                    BucketName = _bucketName,
                    Objects = response.S3Objects.Select(o => new KeyVersion { Key = o.Key }).ToList()
                };

               
                await _amazonS3clinet.DeleteObjectsAsync(deleteRequest);
            }
        }

        public async Task<MemoryStream> GetLocalFileAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            var memoryStream = new MemoryStream();
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0; // Reset the stream position
            return memoryStream;
        }

        public async Task<MemoryStream> GetS3FileAsync(string bucketName, string objectKey)
        {
            var response = await _amazonS3clinet.GetObjectAsync(bucketName, objectKey);

            var memoryStream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0; // Reset the stream position
            return memoryStream;
        }


    }
}
