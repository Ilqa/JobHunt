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

        Task AddJob(Job job);

        Task PublishJob(int jobId);
        Task RemoveJob(int jobId);
        Task HideJob(int jobId);
        //IQueryable<Job> GetAllJobs();
        Task<List<Job>> GetJobsForLocations(List<int> locationIds);
        //Task<int?> GetProfileIdByUserID(int userId);
        // Task UpdateProfileAsync(UserProfile profile);
        //Task<string> UploadFile(int userId, IFormFile file);
        Task<List<Job>> GetAllJobs();
        Task<List<Job>> GetJobsForCity(string city);
    }
}