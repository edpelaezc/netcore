using System;
using Shared.DataTransferObjects;

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
    }
}

