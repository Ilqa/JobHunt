
using JobHunt.Configurations;
using JobHunt.Database.Entities;
using JobHunt.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IRepositoryAsync<UserProfile> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileRepository(IRepositoryAsync<UserProfile> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
          
            _unitOfWork = unitOfWork;
        }

        public IQueryable<UserProfile> Profiles => _repository.Entities;

        public async Task CreateProfileAsync(UserProfile profile) => await _repository.AddAsync(profile);// await _unitOfWork.Commit();

        public async Task<UserProfile> GetProfileAsync(int userId)
        {
            return _repository.Entities.Include(p => p.User).Include(p => p.JobHistory).Include(p=> p.EducationDetails).FirstOrDefault(p => p.UserId == userId);
        }

        public async Task UpdateProfileAsync(UserProfile profile)
        {
            await _repository.UpdateAsync(profile);
            await _unitOfWork.Commit();
        }

        //  public async Task<int?> GetProfileIdByUserID(int userId) => await _repository.Entities.FirstOrDefault(p => p.UserId == userId)?.ProfileId;

        //public async Task<string> UploadFile(int userId, IFormFile file)
        //{
        //    var profile = _repository.Entities.FirstOrDefault(p => p.UserId == userId);
        //    if (profile == null)
        //        return "User Profile Not Found";

        //    FileInfo info = new(file.FileName);
        //    var fileType = FileHandling.GetFiletype(info.Extension);
        //    if (fileType == Enums.FileType.Invalid)
        //        return " Invalid File Type";

        //    var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
        //    path += "/JobHuntFiles";
        //    //var path2 = Directory.GetCurrentDirectory();
            
        //    //"D:\\JobHuntFiles";  //_appConfig.FilePAth;
        //    if (!Directory.Exists(path))
        //        Directory.CreateDirectory(path);

        //    //file size 2mb limit?|
        //    using var dataStream = new MemoryStream();

        //    await file.CopyToAsync(dataStream);
        //    var videoData = dataStream.ToArray();

        //    if (fileType == Enums.FileType.Video)
        //    {
        //        profile.VideoFileData = videoData;
        //        profile.VideoFileName = FileHandling.ConvertVideoName(file.FileName, userId);
        //        using FileStream fileStream = new(Path.Combine(path, profile.VideoFileName), FileMode.Create);
        //        await file.CopyToAsync(fileStream);
        //    }
        //    else if (fileType == Enums.FileType.Document || fileType == Enums.FileType.PDF)
        //    {
        //        profile.ResumeFileData = videoData;
        //        profile.ResumeFileName = FileHandling.ConvertResumeName(file.FileName, userId);
        //        using FileStream fileStream = new(Path.Combine(path, profile.ResumeFileName), FileMode.Create);
        //        await file.CopyToAsync(fileStream);
        //    }

        //    await _repository.UpdateAsync(profile);
        //    await _unitOfWork.Commit();

        //    return "File Uploaded Successfully";

        //}

    }
}
