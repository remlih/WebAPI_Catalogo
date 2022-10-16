using Catalog.Application.Interfaces.Common;

namespace Catalog.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}