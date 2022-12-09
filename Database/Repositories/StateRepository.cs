using JobHunt.Database.Entities;
using JobHunt.Extensions;
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

        public StateRepository(IRepositoryAsync<State> repository) => _repository = repository;

        public IQueryable<State> States { get; }

        public async Task<List<State>> GetFilteredStates(int countryId, string searchText)
        {
            var filteredStates = await _repository.Entities.Where(c => c.country_id == countryId).ToListAsync();
            
            if (searchText.IsNotNullOrEmpty())
                filteredStates = filteredStates.Where(c => c.name.StartsWithIgnoreCase(searchText)).ToList();

            return filteredStates;
        }
    }
}