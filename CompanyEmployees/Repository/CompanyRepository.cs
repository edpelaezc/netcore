using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext): base(repositoryContext)
		{
		}

		public IEnumerable<Company> GetAllCompanines(bool trackChanges) =>
			FindAll(trackChanges)
			.OrderBy(c => c.Name)
			.ToList();

#pragma warning disable CS8603 // Possible null reference return.
        public Company GetCompany(Guid companyId, bool trackChanges) =>
			FindByCondition(c => c.Id.Equals(companyId), trackChanges)
			.SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.

        public void CreateCompany(Company company) => Create(company);

		public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
			FindByCondition(x => ids.Contains(x.Id), trackChanges).ToList();

		public void DeleteCompany(Company company) => Delete(company);
	}
}

