using Catalog.Application.Interfaces.Common;
using Catalog.Application.Requests.Identity;
using Catalog.Application.Responses.Identity;
using Catalog.Shared.Wrapper;
using System.Threading.Tasks;

namespace Catalog.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}