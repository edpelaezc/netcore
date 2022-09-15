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

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
			FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
			.OrderBy(e => e.Name)
			.ToList();


#pragma warning disable CS8603 // Possible null reference return.
        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
			FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
			.SingleOrDefault();
#pragma warning restore CS8603 // Possible null reference return.

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
		{
			employee.CompanyId = companyId;
			Create(employee);
		}

		public void DeleteEmployee(Employee employee) => Delete(employee);

	}
}

