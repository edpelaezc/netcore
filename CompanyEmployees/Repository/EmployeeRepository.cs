using System;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
		{
            var employees = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
									.OrderBy(e => e.Name)
									.Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
									.Take(employeeParameters.PageSize)
                                    .ToListAsync();

			var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges).CountAsync();

			return new PagedList<Employee>(employees, count, employeeParameters.PageNumber, employeeParameters.PageSize);
        }

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

