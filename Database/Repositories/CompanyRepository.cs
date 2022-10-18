using JobHunt.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobHunt.Database.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IRepositoryAsync<Company> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyRepository(IRepositoryAsync<Company> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;

            _unitOfWork = unitOfWork;
        }


        public IQueryable<Company> Companies => _repository.Entities;

        public async Task AddCompany(Company company)
        {
            await _repository.AddAsync(company);
            await _unitOfWork.Commit();
        }

        public Task<List<Company>> GetAllCompanies()
        {
            return Companies.ToListAsync();
        }
    }
}