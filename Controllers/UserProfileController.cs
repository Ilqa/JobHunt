using JobHunt.Database.Repositories;
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


        private readonly IUserProfileRepository _repository;

        public UserProfileController(IUserProfileRepository repository)
        {
            _repository = repository;   
        }

        [HttpPost]
        public async Task<string> UploadVideoResume(IFormFile file, int userId)
        {
            //var httpRequest = HttpContext.Request;
            //var file = HttpContext.Request.Form.Files.GetFile("CrawlSourceData.xls");

            FileInfo info = new FileInfo(file.Name);
            info.Extension;

            return await _repository.UploadFile(userId, file);
        }       
    }
}
