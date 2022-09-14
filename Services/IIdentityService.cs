
using System.Threading.Tasks;

namespace BooksBot.API.Services
{
    public interface IIdentityService
    {

        Task<string> Login(string email, string password);

        //Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}