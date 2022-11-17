using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface IUserProfileRepository
    {
        IQueryable<UserProfile> Profiles { get; }

        Task<int> CreateProfileAsync(UserProfile profile);
        //Task<int?> GetProfileIdByUserID(int userId);
        Task UpdateProfileAsync(UserProfile profile);
       // Task<string> UploadFile(int userId, IFormFile file);
        Task<UserProfile> GetProfileAsync(int userId);
    }
}