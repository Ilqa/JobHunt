using JobHunt.DTO;
using JobHunt.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public interface IReferenceDataService
    {
        Task<Result<List<SkillDto>>> GetAllSkills();
        Task<Result<List<UserTypeDto>>> GetAllUserTypes();
        Task<IResult> AddSkill(SkillDto skill);
        Task<Result<List<CompanyDto>>> GetAllCompanies();
        Task<IResult> AddCompany(CompanyDto company);
    }
}
