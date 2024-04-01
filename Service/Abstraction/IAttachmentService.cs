using TaskMate.DTOs.AttachmentD;

namespace TaskMate.Service.Abstraction;

public interface IAttachmentService
{
    Task CreateAsync(CreateAttachmentDto createAttachmentDto);
    Task<string> UploadFileAsync(IFormFile file);

}
