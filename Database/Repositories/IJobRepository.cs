using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }

        Task<Job> AddJob(Job job);

        Task PublishOrUnpublishJob(int jobId);
        Task RemoveJob(int jobId);
        Task HideOrUnhideJob(int jobId);
        Task<List<Job>> GetJobsForLocations(List<int> locationIds);
       
        Task<List<Job>> GetAllJobs();
        Task<Job> GetJobById(int id);
    }
}