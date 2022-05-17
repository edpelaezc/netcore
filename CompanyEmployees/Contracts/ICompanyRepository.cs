using System;
using Entities.Models;

namespace Contracts
{
	public interface ICompanyRepository
	{
		IEnumerable<Company> GetAllCompanines(bool trackChanges);
	}
}

