using System;
using Shared.DataTransferObjects;
using Entities.Models; 

namespace Service.Contracts
{
	public interface IEmployeeService
	{
		IEnumerable<EmployeeDTO> GetEmployees(Guid companyId, bool trackChanges);

		EmployeeDTO GetEmployee(Guid companyId, Guid id, bool trackChanges);

		EmployeeDTO CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDTO employeeForCreation, bool trackChanges);

		void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);

        void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDTO employeeForUpdate, bool compTrackChanges,
									  bool empTrackChanges);

		(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid id, bool compTrackChanges,
			bool empTrackChanges);

		void SaveChangesForPatch(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity);
    }
}

