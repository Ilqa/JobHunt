using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using JobHunt.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public class JobService : IJobService
    {

        private readonly IMapper _mapper;
        private readonly IJobRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public JobService(IJobRepository repository, IMapper mapper, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> AddJob(JobDto job)
        {
            var jobId = await _repository.AddJob(_mapper.Map<Job>(job));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync($"Job Created {jobId}");
        }

        public async Task<List<JobDto>> GetAllJobs()
        {
            var jobs = await _repository.GetAllJobs();
            return _mapper.Map<List<JobDto>>(jobs);
        }

        public async Task<JobDto> GetJobById(int id)
        {
            var job = await _repository.GetJobById(id);
            return _mapper.Map<JobDto>(job);
        }

        public async Task<List<JobDto>> GetJobsForCity(string city)
        {
            var jobs = await _repository.GetJobsForCity(city);
            return _mapper.Map<List<JobDto>>(jobs);
        }

        public async Task<List<JobDto>> GetJobsForLocations(List<int> locationIds)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IResult> HideOrUnhideJob(int jobId)
        {
            await _repository.HideOrUnhideJob(jobId);
            await _unitOfWork.Commit();
            return await Result.SuccessAsync($"Job Updated");
        }

        public async Task<IResult> PublishOrUnpublishJob(int jobId)
        {
            await _repository.PublishOrUnpublishJob(jobId);
            await _unitOfWork.Commit();
            return await Result.SuccessAsync($"Job Updated");
        }

        public async Task<IResult> RemoveJob(int jobId)
        {
            await _repository.RemoveJob(jobId);
            await _unitOfWork.Commit();
            return await Result.SuccessAsync($"Job Updated");
        }
    }
}
