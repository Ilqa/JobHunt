﻿using AutoMapper;
using JobHunt.Database.Entities;
using JobHunt.Database.Repositories;
using JobHunt.DTO;
using JobHunt.Wrappers;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobHunt.Services
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly RoleManager<UserType> _roleManager;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ReferenceDataService(ISkillRepository skillRepository, ICompanyRepository companyRepositor, RoleManager<UserType> roleManager, IMapper mapper, IUnitOfWork unitOfWork, ICountryRepository countryRepository, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _skillRepository = skillRepository;
            _companyRepository = companyRepositor;
            _mapper = mapper;
            _roleManager = roleManager;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IResult> AddCompany(CompanyDto company)
        {
            await _companyRepository.AddCompany(_mapper.Map<Company>(company));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Company Added Successfully");
        }

        public async Task<IResult> AddSkill(SkillDto skill)
        {
           await _skillRepository.AddSkill(_mapper.Map<Skill>(skill));
            await _unitOfWork.Commit();
            return await Result.SuccessAsync("Skill Added Successfully");
        }

        public async Task<Result<List<CompanyDto>>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAllCompanies();
            return await Result<List<CompanyDto>>.SuccessAsync( _mapper.Map<List<CompanyDto>>(companies));
        }

        public async Task<Result<List<SkillDto>>> GetAllSkills()
        {
            var skills = await _skillRepository.GetAllSkills();
            return await Result<List<SkillDto>>.SuccessAsync( _mapper.Map<List<SkillDto>>(skills));
        }

        public async Task<Result<List<UserTypeDto>>> GetAllUserTypes()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return await Result<List<UserTypeDto>>.SuccessAsync(_mapper.Map<List<UserTypeDto>>(roles));
        }
     
        public async Task<Result<List<Country>>> GetCountries(string searchText) => await Result<List<Country>>.SuccessAsync(_countryRepository.GetFilteredCountries(searchText).Result);

        public async Task<Result<List<State>>> GetStates(int countryId, string searchText) => await Result<List<State>>.SuccessAsync(_stateRepository.GetFilteredStates(countryId, searchText).Result);

        public async Task<Result<List<City>>> GetCities(int countryId, int? stateId, string searchText) => await Result<List<City>>.SuccessAsync(_cityRepository.GetFilteredCities(countryId, stateId, searchText).Result);

        public Result<List<string>> GetFeaturedFiles()
        {
            return Result<List<string>>.Success(new List<string>() { "https://www.youtube.com/watch?v=naIkpQ_cIt0", "https://www.youtube.com/watch?v=Pt2ZZBZ4Mow", "https://youtu.be/PYuPmNFHTog" });
        }
    }
}
