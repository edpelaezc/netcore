using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{
		}

		public async  Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.OrderBy(c => c.Name)
			.ToListAsync();

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
			await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
			.SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        public void CreateCompany(Company company) => Create(company);

		public async  Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
			await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

		public void DeleteCompany(Company company) => Delete(company);
	}
}

