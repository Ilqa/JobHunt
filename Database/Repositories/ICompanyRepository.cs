using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface ICompanyRepository
    {
        IQueryable<Company> Companies { get; }

        Task AddCompany(Company company);
        //Task<int?> GetProfileIdByUserID(int userId);
       // Task UpdateProfileAsync(UserProfile profile);
        //Task<string> UploadFile(int userId, IFormFile file);
        Task<List<Company>> GetAllCompanies();
    }
}