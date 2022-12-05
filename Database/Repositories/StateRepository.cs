using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly IRepositoryAsync<State> _repository;
       

        public StateRepository(IRepositoryAsync<State> repository)
        {
            _repository = repository;

          
        }

        public IQueryable<State> States { get; }

        public async Task<List<State>> GetFilteredCountries(int countryId, string searchText)
        {
            return await States.Where(s => s.Name.StartsWith(searchText)).ToListAsync();    
        }
    }
}