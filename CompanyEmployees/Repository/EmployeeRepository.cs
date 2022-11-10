using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, bool trackChanges) =>
			await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
			.OrderBy(e => e.Name)
			.ToListAsync();


#pragma warning disable CS8603 // Possible null reference return.
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
			await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
			.SingleOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
		{
			employee.CompanyId = companyId;
			Create(employee);
		}

		public void DeleteEmployee(Employee employee) => Delete(employee);

	}
}

