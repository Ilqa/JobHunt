using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly IRepositoryAsync<Job> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public JobRepository(IRepositoryAsync<Job> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

            _unitOfWork = unitOfWork;
        }


        public IQueryable<Job> Jobs => _repository.Entities.Include(j=> j.RequiredSKills);

      // IQueryable<Job> IJobRepository.Skills { get; }

        public async Task<int> AddJob(Job job)
        {
            var jobId = await _repository.AddAsync(job);
            await _unitOfWork.Commit();
            return jobId.Id;
        }

        public Task<List<Job>> GetAllJobs()
        {
           return Jobs.ToListAsync();
        }

       

        public async Task<List<Job>> GetJobsForLocations(List<int> locationIds)
        {
             return new List<Job>();
   
        }

        public async Task<List<Job>> GetJobsForCity(string city) => await Jobs.Where(j => j.City.Equals(city)).ToListAsync();

        public async Task<Job> GetJobById(int Id) => await Jobs.FirstOrDefaultAsync(j => j.Id == Id);

        public async Task PublishOrUnpublishJob(int jobId)
        {
           var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsPublished = !job.IsPublished;
            await _unitOfWork.Commit();
        }

        public async Task RemoveJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsActive = false;
            await _unitOfWork.Commit();
        }

        public async Task HideOrUnhideJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsHidden = !job.IsHidden;
            await _unitOfWork.Commit();
        }
    }
}