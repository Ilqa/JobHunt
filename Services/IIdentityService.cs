using JobHunt.DTO.Identity;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public interface IIdentityService
    {

        Task<TokenResponse> Login(TokenRequest model);

        //Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}