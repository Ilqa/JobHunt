using JobHunt.Database.Entities;
using JobHunt.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IRepositoryAsync<Country> _repository;

        public CountryRepository(IRepositoryAsync<Country> repository) => _repository = repository;

        public IQueryable<Country> Countries => _repository.Entities;

        public async Task<List<Country>> GetAllCountries() => await _repository.Entities.ToListAsync();

        public async Task<List<Country>> GetFilteredCountries(string searchText)// => await _repository.Entities.Where(c => c.Name.StartsWith(searchText)).ToListAsync();
        {
            var countries = await _repository.Entities.ToListAsync();
           
            if(searchText.IsNotNullOrEmpty())
                countries = countries.Where(c => c.name.StartsWithIgnoreCase(searchText)).ToList();

            return countries;
        }
           
        
    }
}