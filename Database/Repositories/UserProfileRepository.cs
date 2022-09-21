
using JobHunt.Database.Entities;
using JobHunt.Helpers;
using Microsoft.AspNetCore.Http;
using MovieReviews.Configurations;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IRepositoryAsync<UserProfile> _repository;
        private readonly AppConfiguration _appConfig;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileRepository(IRepositoryAsync<UserProfile> repository, AppConfiguration appConfig, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _appConfig = appConfig;
            _unitOfWork = unitOfWork;   
        }

        public IQueryable<UserProfile> Profiles => _repository.Entities;

        public async Task CreateProfileAsync(UserProfile profile)
        {
            await _repository.AddAsync(profile);
            await _unitOfWork.Commit();
        }

            public async Task UpdateProfileAsync(UserProfile profile)
        {
            await _repository.UpdateAsync(profile);
            await _unitOfWork.Commit();
        }

      //  public async Task<int?> GetProfileIdByUserID(int userId) => await _repository.Entities.FirstOrDefault(p => p.UserId == userId)?.ProfileId;

        public async Task<string> UploadFile(int userId, IFormFile file)
        {
            var profile = _repository.Entities.FirstOrDefault(p => p.UserId == userId);
            if (profile == null)
                return "File Upload Failed";

            FileInfo info = new(file.FileName);
            var fileType = Enums.FileType.Video;//FileHandling.GetFiletype(info.Extension);
            if (fileType == Enums.FileType.Invalid)
                return " Invalid File Type";

            var path = _appConfig.FilePAth;  // Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //using (FileStream fileStream = new(Path.Combine(path, file.FileName), FileMode.Create))
            //{
            //    await file.CopyToAsync(fileStream);
            //}


            //file size 2mb limit?|
            using var dataStream = new MemoryStream();

            await file.CopyToAsync(dataStream);
            var videoData = dataStream.ToArray();

            if (fileType == Enums.FileType.Video)
            {
                profile.VideoFileData = videoData;
                profile.VideoFileName = FileHandling.ConvertVideoName(file.Name, userId);
                using FileStream fileStream = new(Path.Combine(path, profile.VideoFileName), FileMode.Create);
                await file.CopyToAsync(fileStream);
            }
            else if (fileType == Enums.FileType.Document || fileType == Enums.FileType.PDF)
            {
                profile.ResumeFileData = videoData;
                profile.ResumeFileName = FileHandling.ConvertResumeName(file.Name, userId);
                using FileStream fileStream = new(Path.Combine(path, profile.ResumeFileName), FileMode.Create);
                await file.CopyToAsync(fileStream);
            }

            await _repository.UpdateAsync(profile);
            await _unitOfWork.Commit();

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
