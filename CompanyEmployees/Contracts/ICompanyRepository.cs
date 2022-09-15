using System;
using Entities.Models;

namespace Contracts
{
	public interface ICompanyRepository
	{
		IEnumerable<Company> GetAllCompanines(bool trackChanges);

		Company GetCompany(Guid companyId, bool trackChanges);

		void CreateCompany(Company company);

		IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

		void DeleteCompany(Company company);
	}
}

