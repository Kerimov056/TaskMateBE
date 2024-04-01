using Google.Cloud.Storage.V1;
using TaskMate.Context;
using TaskMate.DTOs.AttachmentD;
using TaskMate.Service.Abstraction;

namespace TaskMate.Service.Implementations;

public class AttachmentService : IAttachmentService
{
    public AppDbContext _appDbContext { get; set; }
    public AttachmentService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task CreateAsync(CreateAttachmentDto createAttachmentDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            throw new DirectoryNotFoundException("Not Found Image");


        var storage = StorageClient.Create();
        var imageUrl = string.Empty;

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var objectName = $"Images/{Guid.NewGuid()}_{file.FileName}";
            var bucketName = "my_proje_bucket";

            await storage.UploadObjectAsync(bucketName, objectName, null, memoryStream);
            var url = $"https://storage.googleapis.com/{bucketName}/{objectName}";

            imageUrl = url;
        }

        return imageUrl;
    }
}
