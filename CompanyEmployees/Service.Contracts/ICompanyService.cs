using System;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges);
	}
}

