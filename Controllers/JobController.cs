
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
        public async Task<string> AddJob(JobDto job)
        {
            var jobId = await _repository.AddJob(_mapper.Map<Job>(job));
            return $"Job Created {jobId}";
        }

        [HttpPut("PublishStatus/{jobId}")]
        public async Task<string> PublishOrUnpublishJob(int jobId)
        {
            await _repository.PublishOrUnpublishJob(jobId);
            return "Job Updated";
        }

        [HttpPut("HideStatus/{jobId}")]
        public async Task<string> HideOrUnhideJob(int jobId)
        {
            await _repository.HideOrUnhideJob(jobId);
            return "Job Updated";
        }

        [HttpPut("Remove/{jobId}")]
        public async Task<string> DeletJob(int jobId)
        {
            await _repository.RemoveJob(jobId);
            return "Job Removed";
        }

        [HttpGet("GetByCity")]
        public async Task<List<JobDto>> GetJobsForCity(string city)
        {
            var jobs = await _repository.GetJobsForCity(city);
            return _mapper.Map<List<JobDto>>(jobs);
        }

        [HttpGet("GetById")]
        public async Task<JobDto> GetJobById(int id)
        {
            var job = await _repository.GetJobById(id);
            return _mapper.Map<JobDto>(job);
        }




    }
}

