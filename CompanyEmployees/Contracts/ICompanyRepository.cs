using System;
using Entities.Models;

namespace Contracts
{
	public interface ICompanyRepository
	{
		IEnumerable<Company> GetAllCompanines(bool trackChanges);
		Company GetCompany(Guid companyId, bool trackChanges);
	}
}

