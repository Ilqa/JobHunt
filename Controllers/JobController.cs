
using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace JobHunt.Controllers
{
    //[Authorize]
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IJobRepository _repository;

        public JobController(IJobRepository repository, IMapper mapper)
        {
            _repository = repository;  
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<string> AddJob(UserProfileDto profile)
        {
            await _repository.AddJob(_mapper.Map<Job>(profile));
            return "Job Created";
        }

        [HttpPut("Publish/{jobId}")]
        public async Task<string> PublishJob(int jobId)
        {
            await _repository.PublishJob(jobId);
            return "Job Published";
        }

        [HttpPut("Hide/{jobId}")]
        public async Task<string> HideJob(int jobId)
        {
            await _repository.HideJob(jobId);
            return "Job Hidden";
        }

        [HttpPut("Remove/{jobId}")]
        public async Task<string> DeletJob(int jobId)
        {
            await _repository.RemoveJob(jobId);
            return "Job Removed";
        }

        [HttpGet]
        public async Task<List<Job>> GetJobsForCity(string city)
        {
            return await _repository.GetJobsForCity(city);
        }

       

       
       
        
        Task<List<Job>> GetJobsForCity(string city);
    }
}
}
