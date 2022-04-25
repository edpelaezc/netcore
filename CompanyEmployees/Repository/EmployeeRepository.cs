using System;
using Contracts;
using Entities.Models;

namespace Repository
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}
	}
}

