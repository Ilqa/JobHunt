using JobHunt.Database.Entities;
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
       

        public CountryRepository(IRepositoryAsync<Country> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

          
        }

        public IQueryable<Country> Countries => _repository.Entities;

        public async Task<List<Country>> GetAllCountries() => await _repository.Entities.ToListAsync();

        public async Task<List<Country>> GetFilteredCountries(string searchText)=>  await _repository.Entities.Where(c=> c.Name.StartsWith(searchText)).ToListAsync();
        
           
        
    }
}