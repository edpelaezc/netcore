using System;
using Shared.DataTransferObjects;
using Entities.Models; 

namespace Service.Contracts
{
	public interface IEmployeeService
	{
		Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(Guid companyId, bool trackChanges);

		Task<EmployeeDTO> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);

		Task<EmployeeDTO> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDTO employeeForCreation, bool trackChanges);

		Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

        Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDTO employeeForUpdate, bool compTrackChanges,
									  bool empTrackChanges);

		Task<(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(Guid companyId, Guid id, bool compTrackChanges,
			bool empTrackChanges);

		Task SaveChangesForPatchAsync(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity);
    }
}

