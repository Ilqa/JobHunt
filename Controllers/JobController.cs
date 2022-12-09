using JobHunt.DTO;
using JobHunt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace JobHunt.Controllers
{
    [Authorize]
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _service;
        public JobController(IJobService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> AddJob(JobDto job) => Ok(await _service.AddJob(job));

        [HttpPut("PublishStatus/{jobId}")]
        public async Task<IActionResult> PublishOrUnpublishJob(int jobId) => Ok(await _service.PublishOrUnpublishJob(jobId));
        
       

        [HttpPut("HideStatus/{jobId}")]
        public async Task<IActionResult> HideOrUnhideJob(int jobId) => Ok(await _service.HideOrUnhideJob(jobId));
       

        [HttpPut("Remove/{jobId}")]
        public async Task<IActionResult> DeletJob(int jobId) => Ok(await _service.RemoveJob(jobId));


        [HttpGet("GetFilteredJobs")]
        public async Task<IActionResult> GetFilteredJobs(JobSearchFilter filter) => Ok(await _service.GetFilteredJobs(filter));
        

        [HttpGet("GetById")]
        public async Task<IActionResult> GetJobById(int id) => Ok(await _service.GetJobById(id));
       




    }
}

