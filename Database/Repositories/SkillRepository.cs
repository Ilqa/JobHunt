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
        private readonly IUnitOfWork _unitOfWork;

        public SkillRepository(IRepositoryAsync<Skill> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

            _unitOfWork = unitOfWork;
        }


        public IQueryable<Skill> Skills => _repository.Entities;

        public async Task AddSkill(Skill skill)
        {
            await _repository.AddAsync(skill);
            await _unitOfWork.Commit();
        }

        public Task<List<Skill>> GetAllSkills()
        {
            return Skills.ToListAsync();
        }
    }
}