using System;
namespace Contracts
{
	public interface IRepositoryManager
	{
		ICompanyRepository Company { get; }
		IEmployeeRepository Employee { get; }
		Task SaveAsync();
	}
}

