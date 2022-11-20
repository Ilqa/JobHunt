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
        

        public JobRepository(IRepositoryAsync<Job> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

        }


        public IQueryable<Job> Jobs => _repository.Entities.Include(j=> j.RequiredSKills);

      // IQueryable<Job> IJobRepository.Skills { get; }

        public async Task<Job> AddJob(Job job)
        {
            return await _repository.AddAsync(job);
           
            //return jobId.Id;
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
           
        }

        public async Task RemoveJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsActive = false;
           
        }

        public async Task HideOrUnhideJob(int jobId)
        {
            var job = await Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
            job.IsHidden = !job.IsHidden;
            
        }
    }
}