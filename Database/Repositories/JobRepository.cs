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


        public IQueryable<Job> Jobs => _repository.Entities;

      // IQueryable<Job> IJobRepository.Skills { get; }

        public async Task AddJob(Job job)
        {
            await _repository.AddAsync(job);
            await _unitOfWork.Commit();
        }

        public Task<List<Job>> GetAllJobs()
        {
           return Jobs.ToListAsync();
        }

       

        public async Task<List<Job>> GetJobsForLocations(List<int> locationIds)
        {
             return new List<Job>();
   
        }

        public async Task<List<Job>> GetJobsForCity(string city)
        {
            return await Jobs.Where(j => j.City.Equals(city, System.StringComparison.Ordinal)).ToListAsync();

        }

        public async Task PublishJob(int jobId)
        {
           var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsPublished = true;
            await _unitOfWork.Commit();
        }

        public async Task RemoveJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsActive = true;
            await _unitOfWork.Commit();
        }

        public async Task HideJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsHidden = true;
            await _unitOfWork.Commit();
        }
    }
}