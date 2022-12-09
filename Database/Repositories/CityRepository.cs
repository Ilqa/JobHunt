using JobHunt.Database.Entities;
using JobHunt.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IRepositoryAsync<City> _repository;
       

        public CityRepository(IRepositoryAsync<City> repository)
        {
            _repository = repository;         
        }

        public IQueryable<City> Countries => _repository.Entities;

        public async Task<List<City>> GetAllCountries() => await _repository.Entities.ToListAsync();

        public async Task<List<City>> GetFilteredCities(int countryId, int? stateId, string searchText)
        {
            var filteredCities = await _repository.Entities.Where(c => c.country_id == countryId).ToListAsync();
            if(stateId.HasValue)
                filteredCities = filteredCities.Where(c=> c.state_id == stateId).ToList();
            if(searchText.IsNotNullOrEmpty())
                filteredCities = filteredCities.Where(c => c.name.StartsWithIgnoreCase(searchText)).ToList();
            return filteredCities;

        } 
        
           
        
    }
}