
using JobHunt.Database.Entities;
using JobHunt.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IRepositoryAsync<UserProfile> _repository;

        public UserProfileRepository(IRepositoryAsync<UserProfile> repository) => _repository = repository;

        public IQueryable<UserProfile> Profiles => _repository.Entities;

        public async Task CreateProfileAsync(UserProfile profile) => await _repository.AddAsync(profile);

        public async Task UpdateProfileAsync(UserProfile profile) => await _repository.UpdateAsync(profile);

        public async Task<int?> GetProfileIdByUserID(int userId) => _repository.Entities.FirstOrDefault(p => p.UserId == userId)?.ProfileId;

        public async Task<string> UploadFile(int userId, IFormFile file)
        {
            var profile = _repository.Entities.FirstOrDefault(p => p.UserId == userId);
            if (profile == null)
                return "File Upload Failed";

            FileInfo info = new FileInfo(file.Name);
            var fileType = FileHandling.GetFiletype(info.Extension);
            if (fileType == Enums.FileType.Invalid)
                return " Invalid File Type";

            using (var dataStream = new MemoryStream())
            {
                await file.CopyToAsync(dataStream);
                var videoData = dataStream.ToArray();
                if (fileType == Enums.FileType.Video)
                {
                    profile.VideoFileData = videoData;
                    profile.VideoFileName = FileHandling.ConvertVideoName(file.Name, userId);
                }
                else if (fileType == Enums.FileType.Document || fileType == Enums.FileType.PDF)
                { profile.ResumeFileData = videoData;
                    profile.ResumeFileName = FileHandling.ConvertResumeName(file.Name, userId);


            }
            return "File Upload Successfully";
        }

        //public async Task<string> UploadTextFile(int userId, IFormFile file)
        //{
        //    var profile = _repository.Entities.FirstOrDefault(p => p.UserId == userId);
        //    if (profile == null)
        //        return "File Upload Failed";

        //    using (var dataStream = new MemoryStream())
        //    {
        //        await file.CopyToAsync(dataStream);
        //        var videoData = dataStream.ToArray();
        //        profile.VideoFileData = videoData;
        //    }

        //    profile.VideoFileName = FileHandling.ConvertVideoName(file.Name, userId);
        //    return "File Upload Successfully";
        //}

    }
}
