using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
	public CompanyRepository(RepositoryContext repositoryContext)
		: base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) =>
		await FindAll(trackChanges)
		.OrderBy(c => c.Name)
		.ToListAsync();

	public async Task<Company> GetCompanyAsync(Guid companyId, bool trackChanges) =>
		await FindByCondition(c => c.Id.Equals(companyId), trackChanges)
		.SingleOrDefaultAsync();

	public void CreateCompany(Company company) => Create(company);

	public void DeleteCompany(Company company) => Delete(company);
}
