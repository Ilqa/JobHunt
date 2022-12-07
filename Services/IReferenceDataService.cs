using JobHunt.Database.Entities;
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
        Task<Result<List<Country>>> GetCountries(string searchText);// => await Result<List<Country>>.SuccessAsync(_countryRepository.GetFilteredCountries(searchText).Result);

        Task<Result<List<State>>> GetStates(int countryId, string searchText);// => await Result<List<State>>.SuccessAsync(_stateRepository.GetFilteredStates(countryId, searchText).Result);

        Task<Result<List<City>>> GetCities(int countryId, int? stateId, string searchText);
    }
}
