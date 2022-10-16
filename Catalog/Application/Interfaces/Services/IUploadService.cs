using Catalog.Application.Requests;

namespace Catalog.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}