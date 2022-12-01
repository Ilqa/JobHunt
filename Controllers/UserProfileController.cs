
using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using JobHunt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace JobHunt.Controllers
{
    [Authorize]
    [Route("api/userProfile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

       // private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserProfileController(IUserService service)
        {
            _service = service;// = repository;  
            //_mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile(UserProfileDto profile) => Ok(await _service.CreateProfileAsync(profile));

        [HttpPost]
        public async Task<IActionResult> UpdateUserProfile(UserProfileDto profile) => Ok(await _service.UpdateProfileAsync(profile));

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProfile(int userId) => Ok(await _service.GetProfileAsync(userId));

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFileResume(IFormFile file, int userId) => Ok(await _service.UploadFile(userId, file));

        [HttpPost("UploadProfilePicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file, int userId) => Ok(await _service.UploadFile(userId, file));

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
