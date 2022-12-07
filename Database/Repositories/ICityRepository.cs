using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface ICityRepository
    {
        IQueryable<City> Countries { get; }

       // Task AddCompany(Company company);
        //Task<int?> GetProfileIdByUserID(int userId);
       // Task UpdateProfileAsync(UserProfile profile);
        //Task<string> UploadFile(int userId, IFormFile file);
       // Task<List<City>> GetAllCountries();

        Task<List<City>> GetFilteredCities(int countryId, int? stateId, string searchText);
    }
}