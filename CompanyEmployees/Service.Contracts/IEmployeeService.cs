using System;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Entities.Models;
using System.Dynamic;
using Entities.LinkModels;

namespace Service.Contracts
{
	public interface IEmployeeService
	{
		Task<(LinkResponse linkResponse, MetaData metaData)> GetEmployeesAsync(Guid companyId, LinkParameters linkParameters, bool trackChanges);

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

