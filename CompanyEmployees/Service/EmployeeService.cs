using System;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
	internal sealed class EmployeeService : IEmployeeService
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(Guid companyId, bool trackChanges)
        {
			var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);

			if (company is null)
				throw new CompanyNotFoundException(companyId);

			var employeesFromDb = await _repository.Employee.GetEmployeesAsync(companyId, trackChanges);
			var employeesDTO = _mapper.Map<IEnumerable<EmployeeDTO>>(employeesFromDb);
			return employeesDTO;
        }

		public async Task<EmployeeDTO> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
		{
			var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
			if (company is null)
				throw new CompanyNotFoundException(companyId);

			var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);
			if (employeeDb is null)
				throw new EmployeeNotFoundException(id);

			var employee = _mapper.Map<EmployeeDTO>(employeeDb);
			return employee;
		}

		public async Task<EmployeeDTO> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDTO employeeForCreation, bool trackChanges)
		{
			var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
			if (company is null)
				throw new CompanyNotFoundException(companyId);

			var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

			_repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
			await _repository.SaveAsync();

			var employeeResponse = _mapper.Map<EmployeeDTO>(employeeEntity);

			return employeeResponse;
		}

		public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
			var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);

			if (company is null)
				throw new CompanyNotFoundException(companyId);

			var employeeForCompany = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);

			if (employeeForCompany is null)
				throw new EmployeeNotFoundException(id);

			_repository.Employee.DeleteEmployee(employeeForCompany);
			await _repository.SaveAsync();
		}

		public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, EmployeeForUpdateDTO employeeForUpdate, bool compTrackChanges,
                                      bool empTrackChanges)
		{
			var company = await _repository.Company.GetCompanyAsync(companyId, compTrackChanges);

			if (company is null)
				throw new CompanyNotFoundException(companyId);

			// track changes = true. 
			var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);

			if (employeeEntity is null)
				throw new EmployeeNotFoundException(id);

			_mapper.Map(employeeForUpdate, employeeEntity);
			await _repository.SaveAsync();
		}

        public async Task<(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync
			(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = await _repository.Employee.GetEmployeeAsync(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDTO>(employeeEntity);

            return (employeeToPatch, employeeEntity);
        }

        public async Task SaveChangesForPatchAsync(EmployeeForUpdateDTO employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            await _repository.SaveAsync();
        }

    }
}

