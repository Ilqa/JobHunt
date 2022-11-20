using JobHunt.DTO;
using JobHunt.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public interface IJobService
    {
        Task<IResult> AddJob(JobDto job);
        Task<IResult> PublishOrUnpublishJob(int jobId);
        Task<IResult> RemoveJob(int jobId);
        Task<IResult> HideOrUnhideJob(int jobId);
        Task<List<JobDto>> GetJobsForLocations(List<int> locationIds);
        Task<List<JobDto>> GetAllJobs();
        Task<List<JobDto>> GetJobsForCity(string city);
        Task<JobDto> GetJobById(int id);
    }
}
