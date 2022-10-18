using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public interface ISkillRepository
    {
        IQueryable<Skill> Skills { get; }

        Task AddSkill(Skill skill);
        //Task<int?> GetProfileIdByUserID(int userId);
       // Task UpdateProfileAsync(UserProfile profile);
        //Task<string> UploadFile(int userId, IFormFile file);
        Task<List<Skill>> GetAllSkills();
    }
}