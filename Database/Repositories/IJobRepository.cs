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

        Task<int> AddJob(Job job);

        Task PublishOrUnpublishJob(int jobId);
        Task RemoveJob(int jobId);
        Task HideOrUnhideJob(int jobId);
        //IQueryable<Job> GetAllJobs();
        Task<List<Job>> GetJobsForLocations(List<int> locationIds);
        //Task<int?> GetProfileIdByUserID(int userId);
        // Task UpdateProfileAsync(UserProfile profile);
        //Task<string> UploadFile(int userId, IFormFile file);
        Task<List<Job>> GetAllJobs();
        Task<List<Job>> GetJobsForCity(string city);
    }
}