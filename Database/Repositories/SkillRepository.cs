using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IRepositoryAsync<Skill> _repository;
       
        public SkillRepository(IRepositoryAsync<Skill> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

           
        }


        public IQueryable<Skill> Skills => _repository.Entities;

        public async Task AddSkill(Skill skill)
        {
            await _repository.AddAsync(skill);
            
        }

        public Task<List<Skill>> GetAllSkills()
        {
            return Skills.ToListAsync();
        }
    }
}