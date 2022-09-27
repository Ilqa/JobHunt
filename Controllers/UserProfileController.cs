
using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace JobHunt.Controllers
{
    //[Authorize]
    [Route("api/userProfile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserProfileRepository _repository;

        public UserProfileController(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<string> CreateUserProfile(UserProfileDto profile)
        {
            await _repository.CreateProfileAsync(_mapper.Map<UserProfile>(profile));
            return "Profile Created";
        }

        [HttpGet("{userId}")]
        public async Task<UserProfileDto> GetProfile(int userId)
        {
            var profile = await _repository.GetProfileAsync(userId);
           return _mapper.Map<UserProfileDto>(profile);
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadVideoResume(IFormFile file, int userId)
        {
            return await _repository.UploadFile(userId, file);
        }

        //[HttpGet("GetVideo")]
        //public async Task<FileContentResult> GetVideo(int userId)
        //{
        //    var fileName = "myfileName.txt";
        //    var mimeType = "application/....";
        //    var fileBytes = _repository.Profiles.First(u => u.UserId == userId)?.VideoFileData;
        //    return new FileContentResult(fileBytes, mimeType)
        //    {
        //        FileDownloadName = fileName
        //    };
           
        //}

        //[HttpGet("GetResume")]
        //public async Task<FileStreamResult> GetResume(string userId)
        //{
        //    var fileName = "myfileName.txt";
        //    var mimeType = "application/....";
        //    Stream stream = new FileStream(@"D:\JobHuntFiles\1_Resume_file.pdf", FileMode.Open);

        //    return new FileStreamResult(stream, mimeType)
        //    {
        //        FileDownloadName = fileName
        //    };
       // }
    }
}
