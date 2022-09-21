
using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
            //var httpRequest = HttpContext.Request;
            //var file = HttpContext.Request.Form.Files.GetFile("CrawlSourceData.xls");
            ;
            await _repository.CreateProfileAsync(_mapper.Map<UserProfile>(profile));
            return "Profile Created";
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadVideoResume(IFormFile file, int userId)
        {
            //var httpRequest = HttpContext.Request;
            //var file = HttpContext.Request.Form.Files.GetFile("CrawlSourceData.xls");

            return await _repository.UploadFile(userId, file);
        }       
    }
}
